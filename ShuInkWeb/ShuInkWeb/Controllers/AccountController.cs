using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ShuInkWeb.Core.Models.AccountModels;
using ShuInkWeb.Data.Entities;

namespace ShuInkWeb.Controllers
{
    public class AccountController : BaseController
    {
        private readonly SignInManager<ApplicationUser> signInManager;

        private readonly UserManager<ApplicationUser> userManager;

        public AccountController(SignInManager<ApplicationUser> _signInManager,
                              UserManager<ApplicationUser> _userManager)
        {
            signInManager = _signInManager;

            userManager = _userManager;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            if (User?.Identity?.IsAuthenticated ?? false)
            {
                return RedirectToAction("Index", "Home");
            }

            var model = new RegisterViewModel();

            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = new ApplicationUser()
            {
                UserName = model.Username,

                Email = model.Email
            };

            var password = await userManager.CreateAsync(user, model.Password);

            if (password.Succeeded)
            {
                return RedirectToAction("Login", "Account");
            }

            foreach (var error in password.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            if (User?.Identity?.IsAuthenticated ?? false)
            {
                return RedirectToAction("index", "Home");
            }

            var model = new LoginViewModel();

            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await userManager.FindByNameAsync(model.Username);

            if (user != null)
            {
                var result = await signInManager.PasswordSignInAsync(user, model.Password, false, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("index", "Home");
                }
            }

            ModelState.AddModelError("", "InvalidLogin");

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}
