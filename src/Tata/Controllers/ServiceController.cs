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
            return View();
        }

        public IActionResult DomainAccount()
        {
            return View();
        }

        public IActionResult DomainCheck()
        {
            return View();
        }

        public IActionResult DomainCheckList()
        {
            return View();
        }

        public IActionResult DomainRegister()
        {
            return View();
        }

        public IActionResult DomainTransfer()
        {
            return View();
        }

        public IActionResult FreeDns()
        {
            return View();
        }

        public IActionResult Hosting()
        {
            return View();
        }

        public IActionResult ProDns()
        {
            return View();
        }

        public IActionResult SecureSocketsLayer()
        {
            return View();
        }

        public IActionResult VirtualPrivateServer()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
