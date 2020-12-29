using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.Endpoints.WebUI.Models.AAA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Endpoints.WebUI.Controllers
{
    [Authorize(Roles ="admin")]
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public UserController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            var users = _userManager.Users.Take(50).ToList();
            return View(users);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser
                {
                    UserName = model.UserName,
                    Email = model.Email
                };
                var result = _userManager.CreateAsync(user, model.Password).Result;
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {

                        ModelState.AddModelError(item.Code, item.Description);
                    }

                }
            }
            return View(model);
        }
        public IActionResult Update(int id)
        {
            var user = _userManager.FindByIdAsync(id.ToString()).Result;
            if (user != null)
            {
                UpdateUserViewModel model = new UpdateUserViewModel
                {
                    Email = user.Email
                };
                return View(user);
            }
                return NotFound();

        }
        [HttpPut]
        public IActionResult Update(UpdateUserViewModel updateUserViewModel,int id)
        {
            var user = _userManager.FindByIdAsync(id.ToString()).Result;
            if (user != null)
            {
                user.Email = updateUserViewModel.Email;
                var result = _userManager.UpdateAsync(user).Result;
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError(item.Code, item.Description);

                    }
                }
                return View(updateUserViewModel);

            }    
            return NotFound();

        }
        public IActionResult Delete(int id)
        {
            var user = _userManager.FindByIdAsync(id.ToString()).Result;
            if (user != null)
            {
                var result = _userManager.DeleteAsync(user).Result;
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError(item.Code, item.Description);

                    }

                }
            }
            return View();


        }
        public IActionResult AddToRole(int id,string roleName)
        {
            var user = _userManager.FindByIdAsync(id.ToString()).Result;
            if (user != null)
            {
                var result = _userManager.AddToRoleAsync(user, roleName).Result;
                    //نمایش رل های کاربر  _userManager.GetUsersInRoleAsync();
            }
            return RedirectToAction("Index");
        }

    }
}
