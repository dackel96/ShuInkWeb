﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ShuInkWeb.Core.Contracts;
using ShuInkWeb.Data.Entities.Identities;
using ShuInkWeb.Extensions;
using static ShuInkWeb.Constants.AreaConstants;
using static ShuInkWeb.Constants.ActionsConstants;

namespace ShuInkWeb.Areas.Artist.Controllers
{
    public class ArtistController : BaseController
    {
        private readonly IAppointmentService appointmentService;

        private readonly UserManager<ApplicationUser> userManager;

        private readonly IArtistService artistService;

        private readonly IMessageService messageService;

        private readonly IGalleryService galleryService;

        private readonly IBlogService postService;

        public ArtistController(IAppointmentService _appointmentService,
            UserManager<ApplicationUser> _userManager,
            IArtistService _artistService,
            IMessageService _messageService,
            IGalleryService _galleryService,
            IBlogService _postService)
        {
            appointmentService = _appointmentService;
            userManager = _userManager;
            artistService = _artistService;
            messageService = _messageService;
            galleryService = _galleryService;
            postService = _postService;
        }

        public async Task<IActionResult> Index()
        {
            if (!(User.IsInRole(ArtistRoleName)))
            {
                return RedirectToPage(InvalidOperation, new { area = IdentityRoleName });
            }

            var id = await artistService.GetArtistIdAsync(User.Id());

            var models = await appointmentService.GetAppointmentsForCurrentArtistAsync(id);

            return View(models);
        }

        public async Task<IActionResult> MyPhotos()
        {
            if (!(User.IsInRole(ArtistRoleName)))
            {
                return RedirectToPage(InvalidOperation, new { area = IdentityRoleName });
            }

            var id = await artistService.GetArtistIdAsync(User.Id());

            var models = await galleryService.GetAllPhotosForAnArtistAsync(id);

            return View(models);
        }

        public async Task<IActionResult> AllMessages()
        {
            if (!(User.IsInRole(ArtistRoleName)))
            {
                return RedirectToPage(InvalidOperation, new { area = IdentityRoleName });
            }

            var models = await messageService.GetAllMessagesAsync();

            return View(models);
        }

        public async Task<IActionResult> MyPosts()
        {
            if (!(User.IsInRole(ArtistRoleName)))
            {
                return RedirectToPage(InvalidOperation, new { area = IdentityRoleName });
            }

            var id = await artistService.GetArtistIdAsync(User.Id());

            var models = await postService.GetPostsForAnArtistAsync(id);

            return View(models);
        }

        public async Task<IActionResult> DeleteMessage(Guid id)
        {
            if (!(User.IsInRole(ArtistRoleName)))
            {
                return RedirectToPage(InvalidOperation, new { area = IdentityRoleName });
            }

            if (!(await messageService.IsExistByIdAsync(id)))
            {
                return RedirectToAction(nameof(AllMessages));
            }

            await messageService.DeleteAsync(id);

            return RedirectToAction(nameof(AllMessages), ArtistControllerName);
        }

    }
}
