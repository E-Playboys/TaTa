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
using Microsoft.AspNetCore.Authorization;
using Tata.Models.ProductModels;

namespace Tata.Areas.Backend.Controllers
{
    [Area("Backend")]
    [Authorize(Roles = "Administrator")]
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
                var product = await GetProductAsync(id);
                model = Mapper.Instance.Map<Product, ProductDetailsViewModel>(product);
            }

            ViewBag.Categories = await BuildProductCategoriesSelectList();
            ViewBag.Currencies = BuildCurrenciesSelectList();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Details(ProductDetailsViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = await BuildProductCategoriesSelectList();
                ViewBag.Currencies = BuildCurrenciesSelectList();
                return View(model);
            }

            var product = Mapper.Instance.Map<ProductDetailsViewModel, Product>(model);

            // clear the placeholder rows
            product.Properties.RemoveAll(x => string.IsNullOrEmpty(x.Name));
            product.Prices.RemoveAll(x => string.IsNullOrEmpty(x.Name));

            using (IUnitOfWork uow = _uowProvider.CreateUnitOfWork())
            {
                var propertyRepo = uow.GetRepository<ProductProperty>();
                var priceRepo = uow.GetRepository<ProductPrice>();
                var productRepo = uow.GetRepository<Product>();

                if (product.Id > 0)
                {
                    foreach (var propertyModel in model.Properties)
                    {
                        if (propertyModel.NeedDelete)
                        {
                            product.Properties.Remove(product.Properties.SingleOrDefault(x => x.Id == propertyModel.Id));
                            var property = await propertyRepo.GetAsync(propertyModel.Id);
                            if (property != null)
                            {
                                propertyRepo.Remove(property);
                            }
                        }
                    }

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