using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tata.Areas.Backend.Models.Product;
using Tata.Entities;
using Tata.Entities.Enums;
using TaTa.DataAccess;
using Tata.Helpers;

namespace Tata.Areas.Backend.Controllers
{
    [Area("Backend")]
    public class ProductController : Controller
    {
        private readonly IUowProvider _uowProvider;

        public ProductController(IUowProvider uowProvider)
        {
            _uowProvider = uowProvider;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var products = await GetProductsAsync(0, 10, x => x.Include(m => m.Category));
            var models = Mapper.Instance.Map<IEnumerable<Product>, IEnumerable<ProductModel>>(products);

            return View(models);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id, int? categoryId = null)
        {
            var model = new ProductDetailsViewModel();
            if (id > 0)
            {
                // get product
                var product = await GetProductAsync(id);
                model = Mapper.Instance.Map<Product, ProductDetailsViewModel>(product);

                // get property groups of product
                var category = await GetCategoryAsync(model.CategoryId);
                model.PropertyGroups = Mapper.Instance.Map<List<ProductPropertyGroup>, List<ProductPropertyGroupModel>>(category.PropertyGroups);

                // set selected value for property groups base on product properties
                foreach (var group in model.PropertyGroups)
                {
                    if(!group.ForDefaultSetup)
                        continue;

                    foreach (var property in product.Properties)
                    {
                        if (group.Type == ProductPropertyGroupType.Ram
                            || group.Type == ProductPropertyGroupType.Strorage
                            || group.Type == ProductPropertyGroupType.Cpu
                            || group.Type == ProductPropertyGroupType.Ip)
                        {
                            if (property.Type == group.Type)
                            {
                                var selectedValue = group.Values.SingleOrDefault(x => x.Value == property.Value);
                                group.SelectedValue = group.Values.IndexOf(selectedValue);
                            }
                        }
                    }
                }
            }
            else
            {
                if (categoryId.HasValue)
                {
                    var category = await GetCategoryAsync(categoryId.Value);
                    if (category != null)
                    {
                        model.CategoryId = categoryId.Value;
                        model.PropertyGroups = Mapper.Instance.Map<List<ProductPropertyGroup>, List<ProductPropertyGroupModel>>(category.PropertyGroups);
                    }
                }
            }

            ViewBag.Categories = await BuildProductCategoriesSelectList();
            ViewBag.Currencies = BuildCurrenciesSelectList();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Details(ProductDetailsViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var product = Mapper.Instance.Map<ProductDetailsViewModel, Product>(model);

            // clean the dummy product prices placeholder row
            product.Prices.RemoveAll(x => string.IsNullOrEmpty(x.Name));

            using (IUnitOfWork uow = _uowProvider.CreateUnitOfWork())
            {
                var propertyRepo = uow.GetRepository<ProductProperty>();
                var priceRepo = uow.GetRepository<ProductPrice>();
                var productRepo = uow.GetRepository<Product>();
                var propertyGroupRepo = uow.GetRepository<ProductPropertyGroup>();

                // create list of new product properties
                var newProperties = new List<ProductProperty>();
                foreach (var groupModel in model.PropertyGroups)
                {
                    var group = await propertyGroupRepo.GetAsync(groupModel.Id, x => x.Include(m => m.Values));
                    if (!group.ForDefaultSetup)
                        continue;

                    ProductPropertyGroupValue selectedValue;
                    if (groupModel.Type == ProductPropertyGroupType.Ram
                        || groupModel.Type == ProductPropertyGroupType.Strorage
                        || groupModel.Type == ProductPropertyGroupType.Cpu
                        || groupModel.Type == ProductPropertyGroupType.Ip)
                    {
                        selectedValue = group.Values.ElementAtOrDefault(groupModel.SelectedValue);
                    }
                    else
                    {
                        selectedValue = group.Values.SingleOrDefault(x => x.Id == groupModel.SelectedValue);
                    }

                    if (selectedValue != null)
                    {
                        var property = new ProductProperty
                        {
                            CreatedDate = DateTime.Now,
                            Name = selectedValue.Name,
                            Description = selectedValue.Description,
                            Value = selectedValue.Value,
                            Price = selectedValue.Price,
                            Currency = selectedValue.Currency,
                            Unit = selectedValue.Unit,
                            Type = group.Type
                        };

                        newProperties.Add(property);
                    }
                }

                // add or update product with the list of new properties
                if (product.Id > 0)
                {
                    // update the new properties
                    product.Properties.Clear();
                    var properties = await propertyRepo.QueryAsync(x => x.ProductId == product.Id);
                    foreach (var property in properties)
                    {
                        propertyRepo.Remove(property);
                    }

                    product.Properties.AddRange(newProperties);

                    // update the prices
                    foreach (var priceModel in model.Prices)
                    {
                        if (priceModel.NeedDelete)
                        {
                            product.Prices.Remove(product.Prices.SingleOrDefault(x => x.Id == priceModel.Id));
                            var price = await priceRepo.GetAsync(priceModel.Id);
                            if (price != null)
                            {
                                priceRepo.Remove(price);
                            }
                        }
                    }

                    productRepo.Update(product);
                }
                else
                {
                    product.Properties.AddRange(newProperties);
                    productRepo.Add(product);
                }

                await uow.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }

        private async Task<ProductCategory> GetCategoryAsync(int id)
        {
            using (IUnitOfWork uow = _uowProvider.CreateUnitOfWork())
            {
                var productRepo = uow.GetRepository<ProductCategory>();
                var result = await productRepo.GetAsync(id, x => x.Include(m => m.PropertyGroups)
                                                                  .ThenInclude(m => m.Values));

                return result;
            }
        }

        private async Task<Product> GetProductAsync(int id)
        {
            using (IUnitOfWork uow = _uowProvider.CreateUnitOfWork())
            {
                var productRepo = uow.GetRepository<Product>();
                var result = await productRepo.GetAsync(id, x => x.Include(m => m.Category)
                                                                  .Include(m => m.Properties)
                                                                  .Include(m => m.Prices));

                return result;
            }
        }

        private async Task<IEnumerable<Product>> GetProductsAsync(int pageIndex, int pageSize, Func<IQueryable<Product>, IQueryable<Product>> includes = null)
        {
            using (IUnitOfWork uow = _uowProvider.CreateUnitOfWork())
            {
                var productRepo = uow.GetRepository<Product>();

                // TODO: get all for demo, fix the client side later
                var result = await productRepo.GetAllAsync(includes: includes);

                return result;
            }
        }

        private async Task<SelectList> BuildProductCategoriesSelectList()
        {
            using (IUnitOfWork uow = _uowProvider.CreateUnitOfWork(false))
            {
                var categoryRepo = uow.GetRepository<ProductCategory>();
                var categories = await categoryRepo.GetAllAsync();
                return new SelectList(categories, nameof(ProductCategory.Id), nameof(ProductCategory.Name));
            }
        }

        private SelectList BuildCurrenciesSelectList()
        {
            var currencies = Utilities.EnumToKeyValuePairs(typeof(Currency));
            return new SelectList(currencies, "Value", "Key");
        }
    }
}