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

namespace Tata.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IUowProvider _uowProvider;

        public HomeController(IUowProvider uowProvider)
        {
            _uowProvider = uowProvider;
            ViewData["BannerDisplay"] = false;
            ViewData["SliderDisplay"] = false;
        }

        public async Task<IActionResult> Index()
        {
            using (IUnitOfWork uow = _uowProvider.CreateUnitOfWork())
            {
                IRepository<Setting> repo = uow.GetRepository<Setting>();
                HomeViewModels model = new HomeViewModels();

                ViewData["BannerDisplay"] = true;
                ViewData["SliderDisplay"] = true;

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

                model.AboutExcert = aboutSettings.SingleOrDefault(s => s.Name == "AboutExcert").Value;
                model.AboutServices = aboutSettings.Where(s => s.Name == "AboutService")
                    .OrderBy(s => s.Priority)
                    .ToList();
                model.AboutPartners = aboutSettings.Where(s => s.Name == "AboutPartner")
                    .OrderBy(s => s.Priority)
                    .ToList();

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
    }
}
