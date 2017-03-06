using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tata.Areas.Backend.Models.Product;
using Tata.Areas.Backend.Models.Setting;
using Tata.Entities;
using TaTa.DataAccess;

namespace Tata.Areas.Backend.Controllers
{
    [Area("Backend")]
    [Authorize(Roles = "Administrator")]
    public class SettingController : Controller
    {
        private readonly IUowProvider _uowProvider;

        public SettingController(IUowProvider uowProvider)
        {
            _uowProvider = uowProvider;
        }

        public IActionResult Index()
        {
            return RedirectToAction("List");
        }

        public async Task<IActionResult> List(int skip = 0, int take = 10)
        {
            using (IUnitOfWork uow = _uowProvider.CreateUnitOfWork())
            {
                var productRepo = uow.GetRepository<Setting>();
                IEnumerable<Setting> settings = (await productRepo.GetAllAsync()).OrderBy(s => s.Id);
                IEnumerable<SettingModel> models = Mapper.Instance.Map<IEnumerable<Setting>,IEnumerable<SettingModel>>(settings);

                return View(models);
            }
        }

        public async Task<IActionResult> Details(int id)
        {
            using (IUnitOfWork uow = _uowProvider.CreateUnitOfWork())
            {
                var productRepo = uow.GetRepository<Setting>();
                Setting setting = await productRepo.GetAsync(id);
                SettingModel models = Mapper.Instance.Map<Setting, SettingModel>(setting);

                return View(models);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Details(SettingModel model)
        {
            return View();
        }
    }
}
