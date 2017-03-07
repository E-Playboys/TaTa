using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tata.Entities;
using Tata.Entities.Enums;
using Tata.Helpers;
using Tata.Models.ConfigureProduct;
using Tata.Models.ProductModels;
using Tata.Models.SessionModels;
using TaTa.DataAccess;

namespace Tata.Controllers
{
    public class ConfigureProductController : BaseController
    {
        private readonly IUowProvider _uowProvider;

        public ConfigureProductController(IUowProvider uowProvider)
        {
            _uowProvider = uowProvider;
        }

        [HttpGet]
        public async Task<IActionResult> Vps(int productId)
        {
            var viewModel = new ConfigureVpsViewModel { ProductId = productId };

            using (IUnitOfWork uow = _uowProvider.CreateUnitOfWork())
            {
                var productRepo = uow.GetRepository<Product>();

                var product = await productRepo.GetAsync(productId, x => x.Include(m => m.Category).Include(m => m.Prices));
                if (product != null)
                {
                    var orderItemsSessionModel = HttpContext.Session.Get<List<OrderItemSessionModel>>(SessionConstants.ORDER_ITEMS_SESSION_MODEL_NAME) ?? new List<OrderItemSessionModel>();
                    if (orderItemsSessionModel.All(x => x.Product.Id != productId))
                    {
                        orderItemsSessionModel.Add(new OrderItemSessionModel
                        {
                            Product = new ProductSessionModel
                            {
                                Id = productId,
                                Name = product.Name,
                                Category = product.Category.Name,
                                Price = new ProductPriceSessionModel
                                {
                                    Price = product.Prices[0].Price,
                                    Currency = product.Prices[0].Currency
                                }
                            }
                        });
                    }

                    HttpContext.Session.Set(SessionConstants.ORDER_ITEMS_SESSION_MODEL_NAME, orderItemsSessionModel);
                    await LoadVpsPropertyGroups(viewModel, productId);
                }
                else
                {
                    return new NotFoundResult();
                }
            }

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Vps(ConfigureVpsViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var orderItemsSessionModel = HttpContext.Session.Get<List<OrderItemSessionModel>>(SessionConstants.ORDER_ITEMS_SESSION_MODEL_NAME);
            var orderItemSessionModel = orderItemsSessionModel.SingleOrDefault(x => x.Product.Id == model.ProductId);
            if (orderItemSessionModel == null)
                return new NotFoundResult();

            orderItemSessionModel.Properties.Clear();
            using (IUnitOfWork uow = _uowProvider.CreateUnitOfWork())
            {
                var propertyGroupRepo = uow.GetRepository<ProductPropertyGroup>();

                var propertyGroups = model.RequiredPropertyGroups.Concat(model.OptionalPropertyGroups);
                foreach (var groupModel in propertyGroups)
                {
                    var group = await propertyGroupRepo.GetAsync(groupModel.Id, x => x.Include(m => m.Values));
                    if (!group.ForUserCustomize)
                        continue;

                    ProductPropertyGroupValue selectedValue;
                    if (groupModel.Type == ProductPropertyGroupType.Ram
                        || groupModel.Type == ProductPropertyGroupType.Storage
                        || groupModel.Type == ProductPropertyGroupType.Cpu
                        || groupModel.Type == ProductPropertyGroupType.Ip)
                    {
                        // -1 to pass the default 0 value
                        selectedValue = group.Values.ElementAtOrDefault(groupModel.SelectedValue - 1);
                    }
                    else
                    {
                        selectedValue = group.Values.SingleOrDefault(x => x.Id == groupModel.SelectedValue);
                    }

                    if (selectedValue != null)
                    {
                        var property = new PropertySessionModel
                        {
                            Type = group.Type,
                            Name = selectedValue.Name,
                            Price = new ProductPriceSessionModel { Price = selectedValue.Price, Currency = selectedValue.Currency },
                            Value = selectedValue.Value,
                            Description = selectedValue.Description,
                            Unit = selectedValue.Unit
                        };

                        orderItemSessionModel.Properties.Add(property);
                    }
                }
            }

            HttpContext.Session.Set(SessionConstants.ORDER_ITEMS_SESSION_MODEL_NAME, orderItemsSessionModel);

            return RedirectToAction("Cart", "Payment");
        }

        private async Task LoadVpsPropertyGroups(ConfigureVpsViewModel viewModel, int productId)
        {
            using (IUnitOfWork uow = _uowProvider.CreateUnitOfWork())
            {
                var productRepo = uow.GetRepository<Product>();
                var propertyGroupRepo = uow.GetRepository<ProductPropertyGroup>();

                var product = await productRepo.GetAsync(productId, x => x.Include(m => m.Category));
                var propertyGroups = await propertyGroupRepo.QueryAsync(x => x.ProductCategoryId == product.CategoryId, includes: x => x.Include(m => m.Values));

                foreach (var group in propertyGroups)
                {
                    if (group.ForUserCustomize)
                    {
                        var groupModel = Mapper.Instance.Map<ProductPropertyGroup, ProductPropertyGroupModel>(group);

                        if (groupModel.Type != ProductPropertyGroupType.Ram
                            && groupModel.Type != ProductPropertyGroupType.Storage
                            && groupModel.Type != ProductPropertyGroupType.Ip)
                        {
                            
                            viewModel.RequiredPropertyGroups.Add(groupModel);
                        }
                        else
                        {
                            // add default value
                            var defaultValue = new ProductPropertyGroupValueModel
                            {
                                Value = "0",
                                Currency = groupModel.Values[0].Currency,
                                Description = groupModel.Values[0].Description,
                                Name = groupModel.Values[0].Name,
                                Unit = groupModel.Values[0].Unit
                            };

                            groupModel.Values.Insert(0, defaultValue);
                            viewModel.OptionalPropertyGroups.Add(groupModel);
                        }
                    }
                }
            }
        }
    }
}
