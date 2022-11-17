using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShuInkWeb.Core.Contracts;
using ShuInkWeb.Core.Models.HappeningModels;

namespace ShuInkWeb.Controllers
{
    [Authorize]
    public class BlogController : Controller
    {
        private readonly IBlogService happeningService;

        public BlogController(IBlogService _happeningService)
        {
            this.happeningService = _happeningService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> All()
        {
            var models = await happeningService.GetHappeningsAsync();

            return View(models);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var model = new HappeningViewModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(HappeningViewModel model)
        {
            await happeningService.AddHappeningAsync(model);

            return RedirectToAction(nameof(All));
        }
    }
}
