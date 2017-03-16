using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tata.Areas.Backend.Models.Users;
using TaTa.DataAccess;
using TaTa.DataAccess.Entities;

namespace Tata.Areas.Backend.Controllers
{
    [Area("Backend")]
    [Authorize(Roles = "Administrator")]
    public class UsersController : Controller
    {
        private readonly IUowProvider _uowProvider;

        public UsersController(IUowProvider uowProvider)
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
                var productRepo = uow.GetRepository<User>();
                IEnumerable<User> user = (await productRepo.GetAllAsync()).OrderBy(s => s.Id);
                IEnumerable<UserModel> models = Mapper.Instance.Map<IEnumerable<User>, IEnumerable<UserModel>>(user);

                return View(models);
            }
        }

        public async Task<IActionResult> Details(int id)
        {
            using (IUnitOfWork uow = _uowProvider.CreateUnitOfWork())
            {
                var productRepo = uow.GetRepository<User>();
                User user = await productRepo.GetAsync(id);
                UserModel models = Mapper.Instance.Map<User, UserModel>(user);

                return View(models);
            }
        }

        [HttpPost]
        public IActionResult Details(UserModel model)
        {
            using (IUnitOfWork uow = _uowProvider.CreateUnitOfWork())
            {
                if (ModelState.IsValid)
                {
                    var UsersRepo = uow.GetRepository<User>();
                    User updateUser = Mapper.Map<UserModel, User>(model);
                    updateUser = UsersRepo.Update(updateUser);
                }

                return RedirectToAction("Details", new { id = model.Id });
            }
        }
    }
}
