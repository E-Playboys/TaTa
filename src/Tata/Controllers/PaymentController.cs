using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tata.Helpers;
using Tata.Models.PaymentModels;
using Tata.Models.SessionModels;

namespace Tata.Controllers
{
    public class PaymentController : BaseController
    {
        public IActionResult PaymentCart()
        {
            var orderItemsSessionModel = HttpContext.Session.Get<List<OrderItemSessionModel>>(SessionConstants.ORDER_ITEMS_SESSION_MODEL_NAME);
            if (orderItemsSessionModel == null)
                return RedirectToActionPermanent("Index", "Home");

            var viewModel = PopulateViewModel(orderItemsSessionModel);

            return View(viewModel);
        }

        public IActionResult UpdatePaymentCart(string data)
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

            return PartialView("_CartItem", viewModel);
        }

        private PaymentCartViewModel PopulateViewModel(List<OrderItemSessionModel> orderItemsSessionModel, List<KeyValuePair<int, int>> quantityData = null)
        {
            decimal netTotal = 0;
            var viewModel = new PaymentCartViewModel();

            foreach (var orderItemSessionModel in orderItemsSessionModel)
            {
                var quantity = quantityData?.Single(x => x.Key == orderItemSessionModel.Product.Id).Value ?? 1;
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

            return viewModel;
        }
    }
}
