namespace ShuInkWeb.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using ShuInkWeb.Controllers.Common;
    using ShuInkWeb.Core.Models.AccountModels;
    using ShuInkWeb.Data.Common.Repositories;
    using ShuInkWeb.Data.Entities.Clients;
    using ShuInkWeb.Data.Entities.Identities;


    public class AccountController : BaseController
    {
        private readonly SignInManager<ApplicationUser> signInManager;

        private readonly UserManager<ApplicationUser> userManager;

        private readonly RoleManager<ApplicationRole> roleManager;

        private readonly IDeletableEntityRepository<Client> clientsDb;

        public AccountController(SignInManager<ApplicationUser> _signInManager,
                              UserManager<ApplicationUser> _userManager,
                              RoleManager<ApplicationRole> _roleManager,
                              IDeletableEntityRepository<Client> _clientsDb)
        {
            signInManager = _signInManager;

            userManager = _userManager;

            roleManager = _roleManager;

            clientsDb = _clientsDb;
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

                Email = model.Email,

                PhoneNumber = model.PhoneNumber,
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

            if (clientsDb.AllAsNoTracking().Any(x => x.PhoneNumber == user.PhoneNumber))
            {
                var clientInfo = clientsDb.All().FirstOrDefault(x => x.PhoneNumber == user.PhoneNumber);
                if (clientInfo != null)
                {
                    clientInfo.UserId = user.Id;
                }
            }

            if (user != null && await userManager.IsInRoleAsync(user, "Artist"))
            {
                var result = await signInManager.PasswordSignInAsync(user, model.Password, false, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Artist", new { area = "Artist" });
                }
            }

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

        //public async Task<IActionResult> CreateRoles()
        //{
        //    await roleManager.CreateAsync(new ApplicationRole("Artist"));
        //    await roleManager.CreateAsync(new ApplicationRole("Client"));
        //    await roleManager.CreateAsync(new ApplicationRole("Administrator"));

        //    return RedirectToAction("Index", "Home");
        //}

        //public async Task<IActionResult> AddUsersToRoles()
        //{
        //    string name1 = "Shu";
        //    string name2 = "yngsovage";

        //    var user = await userManager.FindByNameAsync(name1);
        //    var user2 = await userManager.FindByNameAsync(name2);

        //    await userManager.AddToRolesAsync(user, new string[] { "Artist", "Administrator" });
        //    await userManager.AddToRoleAsync(user2, "Artist");

        //    return RedirectToAction("Index", "Home");
        //}
    }
}
