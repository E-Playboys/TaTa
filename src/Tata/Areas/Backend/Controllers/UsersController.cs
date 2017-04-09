using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tata.Areas.Backend.Models.Users;
using TaTa.DataAccess.Entities;

namespace Tata.Areas.Backend.Controllers
{
    [Area("Backend")]
    [Authorize(Roles = "Administrator")]
    public class UsersController : Controller
    {
        private readonly UserManager<User> _userManager;

        public UsersController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return RedirectToAction("List");
        }

        public async Task<IActionResult> List()
        {
            List<User> users = await _userManager.Users.ToListAsync();
            List<UserModel> models = Mapper.Map<List<User>, List<UserModel>>(users);

            for (int i = 0; i < users.Count; i++)
            {
                models[i].Roles = await _userManager.GetRolesAsync(users[i]);
            }

            return View(models);
        }

        public async Task<IActionResult> Details(string id)
        {
            User user = await _userManager.Users.SingleOrDefaultAsync(u => u.Id == id);
            UserModel model = Mapper.Map<User, UserModel>(user);

            if (user != null)
            {
                model.Roles = await _userManager.GetRolesAsync(user);
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Details(UserModel model)
        {
            User updateUser = Mapper.Map<UserModel, User>(model);
            var result = await _userManager.UpdateAsync(updateUser);
            return RedirectToAction("Details", new { id = model.Id });

        }
    }
}
