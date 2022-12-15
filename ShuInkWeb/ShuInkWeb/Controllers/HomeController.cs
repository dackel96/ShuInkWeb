using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShuInkWeb.Controllers.Common;
using static ShuInkWeb.Constants.AreaConstants;
using static ShuInkWeb.Constants.ActionsConstants;
using ShuInkWeb.Core.Models.MessageModels;
using ShuInkWeb.Core.Contracts;
using ShuInkWeb.Extensions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.Extensions.Logging;
using ShuInkWeb.Models;
using System.Diagnostics;

namespace ShuInkWeb.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IMessageService messageService;

        private readonly IGalleryService galleryService;

        private readonly ILogger<HomeController> logger;

        public HomeController(IMessageService _messageService, IGalleryService _galleryService, ILogger<HomeController> _logger)
        {
            messageService = _messageService;
            galleryService = _galleryService;
            logger = _logger;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            if (User.IsInRole(ArtistRoleName))
            {
                return RedirectToAction(IndexConst, ArtistRoleName, new { area = ArtistAreaName });
            }

            var models = await galleryService.GetLastFivePhotosAsync();

            return View(models);
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult ContactUs([FromForm] IFormFile file)
        {
            var model = new MessageViewModel();

            if (User.Id() != null)
            {
                model.UserId = User.Id();
            }

            return View(model);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> ContactUs([FromForm] IFormFile file, MessageViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await messageService.AddAsync(model, file);

            return RedirectToAction(IndexConst, HomeConst);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            var feature = this.HttpContext.Features.Get<IExceptionHandlerFeature>();

            logger.LogError(feature!.Error, "TraceIdentifier: {0}", Activity.Current?.Id ?? HttpContext.TraceIdentifier);

            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //TO DO Interface of HomePage
    }
}