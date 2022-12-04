using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShuInkWeb.Core.Contracts;
using ShuInkWeb.Core.Models.HappeningModels;
using ShuInkWeb.Controllers.Common;

namespace ShuInkWeb.Controllers
{
    public class BlogController : BaseController
    {
        private readonly IBlogService happeningService;

        public BlogController(IBlogService _happeningService)
        {
            this.happeningService = _happeningService;
        }

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

        public async Task<IActionResult> Details(Guid id)
        {
            if (await happeningService.HappeningExist(id))
            {
                RedirectToAction(nameof(All));
            }

            var model = await happeningService.GetSingleHappeningAsync(id);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            if ((await happeningService.HappeningExist(id) == false))
            {
                return RedirectToAction(nameof(All));
            }

            var post = await happeningService.GetSingleHappeningAsync(id);

            var model = new HappeningViewModel()
            {
                Id = post.Id,
                Title = post.Title,
                Content = post.Content,
                ImageUrl = post.ImageUrl
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, HappeningViewModel model)
        {
            if (id != model.Id)
            {
                return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
            }
            if ((await happeningService.HappeningExist(id) == false))
            {
                return RedirectToAction(nameof(All));
            }
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await happeningService.Edit(id, model);

            return RedirectToAction(nameof(All));
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            await happeningService.Delete(id);

            return RedirectToAction(nameof(All));
        }
    }
}
