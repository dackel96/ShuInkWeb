using AspNetCoreHero.ToastNotification.Abstractions;
using AspNetCoreHero.ToastNotification.Notyf;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShuInkWeb.Controllers.Common;
using ShuInkWeb.Models;
using System.Diagnostics;
using static System.Reflection.Metadata.BlobBuilder;

namespace ShuInkWeb.Controllers
{
    public class HomeController : BaseController
    {
        private readonly INotyfService notyfService;

        public HomeController(INotyfService _notyfService)
        {
            notyfService = _notyfService;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        //TO DO Interface of HomePage
    }
}