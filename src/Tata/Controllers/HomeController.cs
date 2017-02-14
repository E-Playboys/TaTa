using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tata.Entities;
using Tata.Data;
using TaTa.DataAccess;
using Tata.Models;
using TaTa.DataAccess.Repositories;
using TaTa.DataAccess.Query;
using Microsoft.EntityFrameworkCore;

namespace Tata.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IUowProvider _uowProvider;

        public HomeController(IUowProvider uowProvider)
        {
            _uowProvider = uowProvider;
        }

        public async Task<IActionResult> Index()
        {
            using (IUnitOfWork uow = _uowProvider.CreateUnitOfWork())
            {
                IRepository<Setting> settingRepo = uow.GetRepository<Setting>();
                IRepository<Product> productRepo = uow.GetRepository<Product>();
                HomeViewModels model = new HomeViewModels();
                IEnumerable<Setting> homeSettings = await settingRepo.QueryAsync(s => s.Section == "Home");
                string productFeatureIds;

                if (homeSettings.Any())
                {
                    model.HomeSliderBox = homeSettings.Where(s => s.Name == "HomeSliderBox")
                        .OrderBy(s => s.Priority)
                        .ToList();

                    model.HomeSliderLink = homeSettings.Where(s => s.Name == "HomeSliderLink")
                        .OrderBy(s => s.Priority)
                        .ToList();

                    model.HomeSliderBanner = homeSettings.Where(s => s.Name == "HomeSliderBanner")
                        .OrderBy(s => s.Priority)
                        .ToList();

                    productFeatureIds = homeSettings.SingleOrDefault(s => s.Name == "HomeProductFeature").Value;
                    Includes<Product> productInclude = new Includes<Product>(query =>
                    {
                        return query.Include(p => p.ProductProperties)
                                    .Include(p => p.ProductPrices);
                    });

                    model.HomeProductFeature = (await productRepo.QueryAsync(p => productFeatureIds.Contains(p.Id.ToString()),
                                                                            null,
                                                                            productInclude.Expression)).ToList();
                }

                return View(model);
            }
        }

        public IActionResult DomainPriceList()
        {
            return View();
        }

        public async Task<IActionResult> About()
        {
            using (IUnitOfWork uow = _uowProvider.CreateUnitOfWork())
            {
                IRepository<Setting> repo = uow.GetRepository<Setting>();
                AboutViewModel model = new AboutViewModel();
                IEnumerable<Setting> aboutSettings = await repo.QueryAsync(s => s.Section == "About");

                if (aboutSettings.Any())
                {
                    model.AboutExcert = aboutSettings.SingleOrDefault(s => s.Name == "AboutExcert").Value;
                    model.AboutServices = aboutSettings.Where(s => s.Name == "AboutService")
                        .OrderBy(s => s.Priority)
                        .ToList();
                    model.AboutPartners = aboutSettings.Where(s => s.Name == "AboutPartner")
                        .OrderBy(s => s.Priority)
                        .ToList();
                }

                return View(model);
            }
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Domain()
        {
            return View();
        }

        public IActionResult Partner()
        {
            return View();
        }

        public IActionResult Promotion()
        {
            return View();
        }

        public IActionResult Support()
        {
            return View();
        }

        public IActionResult VpsPage()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        public IActionResult Cart()
        {
            return View();
        }
    }
}
