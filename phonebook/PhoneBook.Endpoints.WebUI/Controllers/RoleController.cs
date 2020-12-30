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
        public IActionResult Create(string roleName)
        {
            MyIdentityRole role = new MyIdentityRole
            {
                Name = roleName
            };
            var result = _roleManager.CreateAsync(role).Result;
            return RedirectToAction("Index");

        }
     }
}
