using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.Endpoints.WebUI.Models.AAA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Endpoints.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<AppUser> _userManager;
        private SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public ViewResult Login(string returnulr)
        {
            return View(new MyLoginModel
            {
                ReturnUrl = returnulr

            });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(MyLoginModel myLoginModel)
        {
            if (ModelState.IsValid)
            {
                AppUser user = await _userManager.FindByNameAsync(myLoginModel.Name);
                if (user == null)
                {
                    user = await _userManager.FindByEmailAsync(myLoginModel.Name);
                }
                if (user != null)
                {
                    await _signInManager.SignOutAsync();

                    if ((await _signInManager.PasswordSignInAsync(user, myLoginModel.Password, false, false)).Succeeded)
                    {
                        return Redirect(myLoginModel?.ReturnUrl ?? "/");

                    }

                }
            }
            ModelState.AddModelError("", "Invalid name or password");
            return View(myLoginModel);
        }
        public async Task<RedirectResult> Logout(string returnurl = "/")
        {
            await _signInManager.SignOutAsync();
            return Redirect(returnurl);
        }
    }
}
//maryambenito || benitomaryam