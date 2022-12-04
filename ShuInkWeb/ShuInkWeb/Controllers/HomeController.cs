namespace ShuInkWeb.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using ShuInkWeb.Controllers.Common;

    public class HomeController : BaseController
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            if (User.IsInRole("Artist"))
            {
                return RedirectToAction("Index", "Artist", new { area = "Artist" });
            }
            return View();
        }

        //TO DO Interface of HomePage
    }
}