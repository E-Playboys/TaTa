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
    public class ServiceController : BaseController
    {
        private IUowProvider _uowProvider;

        public ServiceController(IUowProvider uowProvider)
        {
            _uowProvider = uowProvider;
            ViewData["BannerDisplay"] = false;
            ViewData["SliderDisplay"] = false;
        }

        public IActionResult Index()
        {
            using (var uow = _uowProvider.CreateUnitOfWork())
            {
                var repo = uow.GetRepository<Setting>();
                IEnumerable<Setting> homePageSettings;
                homePageSettings = repo.GetAll();

                ViewData["BannerDisplay"] = true;
                ViewData["SliderDisplay"] = true;

                return View(homePageSettings);
            }
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
