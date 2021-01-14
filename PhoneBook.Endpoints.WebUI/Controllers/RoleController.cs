using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.Endpoints.WebUI.Models.AAA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Endpoints.WebUI.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleManager<MyIdentityRole> _roleManager;

        public RoleController(RoleManager<MyIdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public IActionResult Index()
        {
            var role = _roleManager.Roles.ToList();
            return View(role);
        }
        //public IActionResult Create(string roleName)
        //{
        //    MyIdentityRole role = new MyIdentityRole
        //    {
        //        Name = roleName
        //    };
        //    var result = _roleManager.CreateAsync(role).Result;
        //    return RedirectToAction("Index");

        //}
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(RoleViewModel role)
        {
            if (ModelState.IsValid)
            {
                MyIdentityRole identityRole = new MyIdentityRole
                {
                    Name = role.UserName
                };
                var result = _roleManager.CreateAsync(identityRole).Result;
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

        public IActionResult Delete(string id)
        {
            var Role = _roleManager.FindByIdAsync(id).Result;
            if (Role != null)
            {
                var result = _roleManager.DeleteAsync(Role).Result;
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
            return NotFound();
        }
        public IActionResult Update(string id)
        {
            var role = _roleManager.FindByIdAsync(id).Result;
            if (role != null)
            {
                RoleViewModel model = new RoleViewModel
                {
                    UserName = role.Name
                };
                return View(model);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public IActionResult Update(string id, RoleViewModel roleViewModel)
        {
            var role = _roleManager.FindByIdAsync(id).Result;
            if (role != null)
            {
                role.Name = roleViewModel.UserName;
                var result = _roleManager.UpdateAsync(role).Result;
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
            return NotFound();
        }
    }
}
