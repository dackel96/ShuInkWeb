using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShuInkWeb.Core.Contracts;
using ShuInkWeb.Core.Models.HappeningModels;
using ShuInkWeb.Controllers.Common;
using static ShuInkWeb.Constants.ActionsConstants;
using static ShuInkWeb.Constants.AreaConstants;
using ShuInkWeb.Extensions;

namespace ShuInkWeb.Controllers
{
    public class BlogController : BaseController
    {
        private readonly IBlogService happeningService;

        private readonly IArtistService artistService;

        public BlogController(IBlogService _happeningService,
            IArtistService _artistService)
        {
            happeningService = _happeningService;
            artistService = _artistService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> All()
        {
            var models = await happeningService.GetPostsAsync();

            return View(models);
        }

        [HttpGet]
        [Authorize(Roles = ArtistRoleName)]
        public IActionResult Add()
        {
            if (!(User.IsInRole(ArtistRoleName)))
            {
                return RedirectToPage(InvalidOperation, new { area = IdentityRoleName });
            }

            var model = new HappeningViewModel();

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = ArtistRoleName)]
        public async Task<IActionResult> Add([FromForm] IFormFile file, HappeningViewModel model)
        {
            if (!(User.IsInRole(ArtistRoleName)))
            {
                return RedirectToPage(InvalidOperation, new { area = IdentityRoleName });
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var id = await artistService.GetArtistIdAsync(User.Id());

            model.ArtistId = id;

            await happeningService.AddAsync(model, file);

            return RedirectToAction(nameof(All));
        }

        [Authorize(Roles = ArtistRoleName)]
        public async Task<IActionResult> Details(Guid id)
        {
            if (!(User.IsInRole(ArtistRoleName)))
            {
                return RedirectToPage(InvalidOperation, new { area = IdentityRoleName });
            }

            if (await happeningService.IsExistAsync(id))
            {
                RedirectToAction(nameof(All));
            }

            var model = await happeningService.GetSinglePostAsync(id);

            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = ArtistRoleName)]
        public async Task<IActionResult> Edit(Guid id, [FromForm] IFormFile file)
        {
            if (!(User.IsInRole(ArtistRoleName)))
            {
                return RedirectToPage(InvalidOperation, new { area = IdentityRoleName });
            }

            if ((await happeningService.IsExistAsync(id) == false))
            {
                return RedirectToAction(nameof(All));
            }

            var post = await happeningService.GetSinglePostAsync(id);

            if (post == null)
            {
                return RedirectToAction(nameof(All));
            }

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
        [Authorize(Roles = ArtistRoleName)]
        public async Task<IActionResult> Edit(Guid id, HappeningViewModel model, [FromForm] IFormFile file)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (!(User.IsInRole(ArtistRoleName)))
            {
                return RedirectToPage(InvalidOperation, new { area = IdentityRoleName });
            }

            if (id != model.Id)
            {
                return RedirectToPage(InvalidOperation, new { area = IdentityRoleName });
            }

            if ((await happeningService.IsExistAsync(id) == false))
            {
                return RedirectToAction(nameof(All));
            }

            await happeningService.EditAsync(id, model, file);

            return RedirectToAction(nameof(All));
        }

        [Authorize(Roles = ArtistRoleName)]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (!(User.IsInRole(ArtistRoleName)))
            {
                return RedirectToPage(InvalidOperation, new { area = IdentityRoleName });
            }

            if ((await happeningService.IsExistAsync(id) == false))
            {
                return RedirectToPage(InvalidOperation, new { area = IdentityRoleName });
            }

            await happeningService.DeleteAsync(id);

            return RedirectToAction(nameof(All));
        }
    }
}
