using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShuInkWeb.Models;
using System.Diagnostics;
using static System.Reflection.Metadata.BlobBuilder;

namespace ShuInkWeb.Controllers
{
    public class HomeController : BaseController
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            //if (User?.Identity?.IsAuthenticated ?? false)
            //{
            //    return RedirectToAction("TO DO", "TO DO");
            //}

            return View();
        }
    }
}