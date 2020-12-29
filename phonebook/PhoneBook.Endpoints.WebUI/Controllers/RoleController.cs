using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Endpoints.WebUI.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
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
            IdentityRole role = new IdentityRole
            {
                Name = roleName
            };
            var result = _roleManager.CreateAsync(role);
            return RedirectToAction("Index");

        }
     }
}
