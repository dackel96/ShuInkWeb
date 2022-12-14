using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Operations;
using ShuInkWeb.Controllers.Common;
using ShuInkWeb.Core.Contracts;
using ShuInkWeb.Core.Models.GalleryModels;
using static ShuInkWeb.Constants.AreaConstants;
using static ShuInkWeb.Constants.ActionsConstants;
using ShuInkWeb.Core.Models.HappeningModels;
using Microsoft.AspNetCore.Identity;
using ShuInkWeb.Data.Entities.Identities;
using ShuInkWeb.Extensions;

namespace ShuInkWeb.Controllers
{
    public class GalleryController : BaseController
    {
        private readonly IGalleryService galleryService;

        private readonly UserManager<ApplicationUser> userManager;

        private readonly IArtistService artistService;

        public GalleryController(IGalleryService _galleryService,UserManager<ApplicationUser> _userManager,IArtistService _artistService)
        {
            galleryService = _galleryService;

            userManager = _userManager;

            artistService = _artistService;
        }

        [HttpGet]
        [Authorize(Roles = ArtistRoleName)]
        public async Task<IActionResult> Add()
        {
            if (!(User.IsInRole(ArtistRoleName)))
            {
                return RedirectToPage(InvalidOperation, new { area = IdentityRoleName });
            }

            var model = new ImageViewModel();

            var id = await artistService.GetArtistIdAsync(User.Id());

            model.ArtistId = id;

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = ArtistRoleName)]
        public async Task<IActionResult> Add([FromForm] IFormFile file, ImageViewModel model)
        {
            if (!(User.IsInRole(ArtistRoleName)))
            {
                return RedirectToPage(InvalidOperation, new { area = IdentityRoleName });
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await galleryService.Add(model, file);

            return RedirectToAction(nameof(All));
        }

        [AllowAnonymous]
        public async Task<IActionResult> All()
        {
            var models = await galleryService.AllPhotos();

            if (!(models.Any()))
            {
                return RedirectToAction(IndexConst, HomeConst);
            }

            return View(models);
        }

        [AllowAnonymous]
        public async Task<IActionResult> AllForAnArtist(Guid id)
        {
            var models = await galleryService.AllPhotosForAnArtist(id);

            if (!(models.Any()))
            {
                return RedirectToAction(IndexConst, HomeConst);
            }

            return View(models);
        }

        [HttpGet]
        [Authorize(Roles = ArtistRoleName)]
        public async Task<IActionResult> Edit(Guid id, [FromForm] IFormFile file)
        {
            if (!(User.IsInRole(ArtistRoleName)))
            {
                return RedirectToPage(InvalidOperation, new { area = IdentityRoleName });
            }

            if ((await galleryService.IsExist(id)) == false)
            {
                return RedirectToAction(nameof(All));
            }

            var model = galleryService.GetSingleImage(id);

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = ArtistRoleName)]
        public async Task<IActionResult> Edit(Guid id, ImageViewModel model, [FromForm] IFormFile file)
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

            if ((await galleryService.IsExist(id) == false))
            {
                return RedirectToAction(nameof(All));
            }

            await galleryService.Edit(id, model, file);

            return RedirectToAction(nameof(All));
        }

        [Authorize(Roles = ArtistRoleName)]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (!(User.IsInRole(ArtistRoleName)))
            {
                return RedirectToPage(InvalidOperation, new { area = IdentityRoleName });
            }

            if ((await galleryService.IsExist(id) == false))
            {
                return RedirectToPage(InvalidOperation, new { area = IdentityRoleName });
            }

            await galleryService.Delete(id);

            return RedirectToAction(nameof(All));
        }

        [Authorize(Roles = ArtistRoleName)]
        public async Task<IActionResult> Details(Guid id)
        {
            if (!(User.IsInRole(ArtistRoleName)))
            {
                return RedirectToPage(InvalidOperation, new { area = IdentityRoleName });
            }

            if (await galleryService.IsExist(id))
            {
                RedirectToAction(nameof(All));
            }

            var model = await galleryService.GetSingleImage(id);

            return View(model);
        }

    }
}
