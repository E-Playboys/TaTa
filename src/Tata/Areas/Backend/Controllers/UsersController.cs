using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tata.Areas.Backend.Models.Users;
using Tata.Data;
using TaTa.DataAccess;
using TaTa.DataAccess.Entities;
using TaTa.DataAccess.Repositories;

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
            List<UserModel> models = Mapper.Instance.Map<List<User>, List<UserModel>>(users);

            return View(users);
        }

        public async Task<IActionResult> Details(string id)
        {
            User user = await _userManager.Users.SingleOrDefaultAsync(u => u.Id == id);
            return View(user);
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
