using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tata.Entities;
using Tata.Data;
using TaTa.DataAccess;

namespace Tata.Controllers
{
    public class HomeController : Controller
    {
        private IUowProvider _uowProvider;

        public HomeController(IUowProvider uowProvider)
        {
            _uowProvider = uowProvider;
        }

        public IActionResult Index()
        {
            using (var uow = _uowProvider.CreateUnitOfWork())
            {
                var repo = uow.GetRepository<Setting>();
                IEnumerable<Setting> homePageSettings;
                homePageSettings = repo.GetAll();
                return View(homePageSettings);
            }
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Domain()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Partner()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Promotion()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Support()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult VpsPage()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
