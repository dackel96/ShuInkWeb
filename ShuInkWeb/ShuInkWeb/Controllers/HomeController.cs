using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShuInkWeb.Controllers.Common;
using static ShuInkWeb.Constants.AreaConstants;
using static ShuInkWeb.Constants.ActionsConstants;
using ShuInkWeb.Core.Models.MessageModels;
using ShuInkWeb.Core.Contracts;
using ShuInkWeb.Extensions;

namespace ShuInkWeb.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IMessageService messageService;

        public HomeController(IMessageService _messageService)
        {
            messageService = _messageService;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            if (User.IsInRole(ArtistRoleName))
            {
                return RedirectToAction(IndexConst, ArtistRoleName, new { area = ArtistAreaName });
            }
            return View();
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

            await messageService.Add(model, file);

            return RedirectToAction(IndexConst, HomeConst);
        }
        //TO DO Interface of HomePage
    }
}