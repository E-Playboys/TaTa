using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Tata.Entities;
using Tata.Entities.Enums;
using Tata.Helpers;
using Tata.Models.AccountViewModels;
using Tata.Models.PaymentModels;
using Tata.Models.SessionModels;
using TaTa.DataAccess;
using TaTa.DataAccess.Entities;

namespace Tata.Controllers
{
    public class PaymentController : BaseController
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IUowProvider _uowProvider;

        public PaymentController(UserManager<User> userManager, SignInManager<User> signInManager, IUowProvider uowProvider)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _uowProvider = uowProvider;
        }

        #region Cart

        public IActionResult Cart()
        {
            var orderItemsSessionModel = HttpContext.Session.Get<List<OrderItemSessionModel>>(SessionConstants.ORDER_ITEMS_SESSION_MODEL_NAME);
            if (orderItemsSessionModel == null)
                return RedirectToActionPermanent("Index", "Home");

            var viewModel = PopulateViewModel(orderItemsSessionModel);

            return View(viewModel);
        }

        public IActionResult UpdateCart(string data)
        {
            var orderItemsSessionModel = HttpContext.Session.Get<List<OrderItemSessionModel>>(SessionConstants.ORDER_ITEMS_SESSION_MODEL_NAME);
            if (orderItemsSessionModel == null)
                return RedirectToActionPermanent("Index", "Home");

            var quantityData = new List<KeyValuePair<int, int>>();
            foreach (var item in data.Split(';'))
            {
                if (string.IsNullOrEmpty(item))
                    continue;

                var productId = int.Parse(item.Split('|')[0]);
                var quantity = int.Parse(item.Split('|')[1]);

                quantityData.Add(new KeyValuePair<int, int>(productId, quantity));
            }

            var viewModel = PopulateViewModel(orderItemsSessionModel, quantityData);

            HttpContext.Session.Set(SessionConstants.ORDER_ITEMS_SESSION_MODEL_NAME, orderItemsSessionModel);

            return PartialView("_CartItem", viewModel);
        }

        private PaymentCartViewModel PopulateViewModel(List<OrderItemSessionModel> orderItemsSessionModel, List<KeyValuePair<int, int>> quantityData = null)
        {
            decimal netTotal = 0;
            var viewModel = new PaymentCartViewModel();

            foreach (var orderItemSessionModel in orderItemsSessionModel)
            {
                var quantity = quantityData?.Single(x => x.Key == orderItemSessionModel.Product.Id).Value ?? orderItemSessionModel.Quantity;
                orderItemSessionModel.Quantity = quantity;

                var item = new PaymentCartItem
                {
                    ProductId = orderItemSessionModel.Product.Id,
                    Name = orderItemSessionModel.Product.Name,
                    Description = orderItemSessionModel.Product.Category,
                    Price = orderItemSessionModel.Product.Price,
                    Quantity = quantity
                };

                viewModel.Items.Add(item);
                netTotal += item.Price.Price * item.Quantity;

                foreach (var property in orderItemSessionModel.Properties)
                {
                    var subItem = new PaymentCartItem
                    {
                        ProductId = orderItemSessionModel.Product.Id,
                        Name = orderItemSessionModel.Product.Name,
                        Description = $"{property.Type} - {property.Name} {property.Value} {property.Unit}",
                        Price = property.Price,
                        Quantity = item.Quantity
                    };

                    item.SubItems.Add(subItem);

                    netTotal += subItem.Price.Price * subItem.Quantity;
                }
            }

            var vat = netTotal * ((decimal)10.0 / 100);
            var grossTotal = netTotal + vat;

            viewModel.GrossTotal = grossTotal;
            viewModel.Vat = vat;
            viewModel.NetTotal = netTotal;
            viewModel.Currency = orderItemsSessionModel[0].Product.Price.Currency;

            var paymentSessionModel = new PaymentSessionModel
            {
                OrderCode = $"TT{DateTime.Now:yyMMdd}{Guid.NewGuid().ToString().Split('-')[1].ToUpper()}",
                GrossTotal = grossTotal,
                Vat = vat,
                NetTotal = netTotal,
                Currency = viewModel.Currency
            };

            HttpContext.Session.Set(SessionConstants.PAYMENT_SESSION_MODEL_NAME, paymentSessionModel);

            return viewModel;
        }

        #endregion

        #region Login

        public IActionResult Account()
        {
            var paymentSessionModel = HttpContext.Session.Get<PaymentSessionModel>(SessionConstants.PAYMENT_SESSION_MODEL_NAME);
            if (paymentSessionModel == null)
                return RedirectToActionPermanent("Index", "Home");

            var viewModel = new PaymentAccountViewModel
            {
                OrderCode = paymentSessionModel.OrderCode,
                GrossTotal = paymentSessionModel.GrossTotal,
                Vat = paymentSessionModel.Vat,
                NetTotal = paymentSessionModel.NetTotal,
                Currency = paymentSessionModel.Currency
            };

            return View(viewModel);
        }

        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return new BadRequestResult();

            var user = await _userManager.FindByEmailAsync(model.Email);
            var result = await _signInManager.PasswordSignInAsync(user.UserName, model.Password, model.RememberMe, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                return new JsonResult(new { success = true });
            }

            return new JsonResult(new { success = false, error = "Username or password is incorrect" });
        }

        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return new BadRequestResult();

            var user = new User { UserName = model.UserName, Email = model.Email, EmailConfirmed = true, FullName = model.FullName, Address = model.Address, PhoneNumber = model.PhoneNumber, Gender = model.Gender, Organization = model.Organization, UserType = string.IsNullOrWhiteSpace(model.Organization) ? UserType.Personal : UserType.Organization};
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                // By default all user is standard user
                await _userManager.AddToRoleAsync(user, UserRoles.Standard);
                await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, UserRoles.Standard));

                // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=532713
                // Send an email with this link
                //var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                //var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: HttpContext.Request.Scheme);
                //await _emailSender.SendEmailAsync(model.Email, "Confirm your account",
                //    $"Please confirm your account by clicking this link: <a href='{callbackUrl}'>link</a>");
                await _signInManager.SignInAsync(user, isPersistent: false);
                return new JsonResult(new { success = true });
            }

            return new JsonResult(new { success = false, error = GetErrors(result) });
        }

        private string GetErrors(IdentityResult result)
        {
            var errorString = "";
            foreach (var error in result.Errors)
            {
                errorString += error.Description;
            }

            return errorString;
        }

        #endregion

        #region Payment Selection

        [HttpGet]
        public async Task<IActionResult> Selection()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);

            var viewModel = new PaymentSelectionViewModel
            {
                PhoneNumber = user.PhoneNumber,
                Email = user.Email,
                ClientName = user.FullName
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Selection(PaymentSelectionViewModel model)
        {
            var orderItemsSessionModel = HttpContext.Session.Get<List<OrderItemSessionModel>>(SessionConstants.ORDER_ITEMS_SESSION_MODEL_NAME);
            var paymentSessionModel = HttpContext.Session.Get<PaymentSessionModel>(SessionConstants.PAYMENT_SESSION_MODEL_NAME);

            if (paymentSessionModel == null || orderItemsSessionModel == null)
                return RedirectToActionPermanent("Index", "Home");

            using (IUnitOfWork uow = _uowProvider.CreateUnitOfWork())
            {
                var orderRepo = uow.GetRepository<Order>();

                var order = new Order
                {
                    PaymentType = model.PaymentType,
                    GrossTotal = paymentSessionModel.GrossTotal,
                    NetTotal = paymentSessionModel.NetTotal,
                    OrderCode = paymentSessionModel.OrderCode,
                    OrderItems = new List<OrderItem>()
                };

                foreach (var item in orderItemsSessionModel)
                {
                    var orderItem = new OrderItem
                    {
                        ProductId = item.Product.Id,
                        Currency = item.Product.Price.Currency,
                        Price = item.Product.Price.Price,
                        Quantity = item.Quantity,
                        ExtraProperties = new List<ProductProperty>()
                    };

                    foreach (var extraProperty in item.Properties)
                    {
                        var productProperty = new ProductProperty
                        {
                            Currency = extraProperty.Price.Currency,
                            Price = extraProperty.Price.Price,
                            Description = extraProperty.Description,
                            Name = extraProperty.Name,
                            Type = extraProperty.Type,
                            Value = extraProperty.Value,
                            Unit = extraProperty.Unit
                        };

                        orderItem.ExtraProperties.Add(productProperty);
                    }

                    order.OrderItems.Add(orderItem);
                }

                orderRepo.Add(order);
                await uow.SaveChangesAsync();
            }

            paymentSessionModel.PaymentType = model.PaymentType;

            HttpContext.Session.Set(SessionConstants.PAYMENT_SESSION_MODEL_NAME, paymentSessionModel);

            return RedirectToAction("Complete", "Payment");
        }

        #endregion

        #region Payment Complete

        public async Task<IActionResult> Complete()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var orderItemsSessionModel = HttpContext.Session.Get<List<OrderItemSessionModel>>(SessionConstants.ORDER_ITEMS_SESSION_MODEL_NAME);
            var paymentSessionModel = HttpContext.Session.Get<PaymentSessionModel>(SessionConstants.PAYMENT_SESSION_MODEL_NAME);
            if (paymentSessionModel == null || orderItemsSessionModel == null)
                return RedirectToActionPermanent("Index", "Home");

            var orderItems = PopulateViewModel(orderItemsSessionModel);
            var viewModel = new PaymentCompleteViewModel()
            {
                PhoneNumber = user.PhoneNumber,
                Email = user.Email,
                ClientName = user.FullName,
                OrderCode = paymentSessionModel.OrderCode,
                GrossTotal = paymentSessionModel.GrossTotal,
                Vat = paymentSessionModel.Vat,
                NetTotal = paymentSessionModel.NetTotal,
                Currency = paymentSessionModel.Currency,
                PaymentType = paymentSessionModel.PaymentType,
                Items = orderItems.Items
            };

            return View(viewModel);
        }

        #endregion
    }
}
