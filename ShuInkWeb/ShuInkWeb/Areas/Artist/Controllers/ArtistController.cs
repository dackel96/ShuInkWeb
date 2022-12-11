using Microsoft.AspNetCore.Identity;
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

        public ArtistController(IAppointmentService _appointmentService,
            UserManager<ApplicationUser> _userManager,
            IArtistService _artistService,
            IMessageService _messageService)
        {
            appointmentService = _appointmentService;
            userManager = _userManager;
            artistService = _artistService;
            messageService = _messageService;
        }

        public async Task<IActionResult> Index()
        {
            if (!(User.IsInRole(ArtistRoleName)))
            {
                return RedirectToPage(InvalidOperation, new { area = IdentityRoleName });
            }

            var id = await artistService.GetArtistIdAsync(User.Id());

            var models = await appointmentService.GetAppointmentsForCurrentArtist(id);

            return View(models);
        }

        public async Task<IActionResult> AllMessages()
        {
            if (!(User.IsInRole(ArtistRoleName)))
            {
                return RedirectToPage(InvalidOperation, new { area = IdentityRoleName });
            }

            var models = await messageService.All();

            return View(models);
        }

        public async Task<IActionResult> DeleteMessage(Guid id)
        {
            if (!(User.IsInRole(ArtistRoleName)))
            {
                return RedirectToPage(InvalidOperation, new { area = IdentityRoleName });
            }

            if (!(await messageService.IsExistById(id)))
            {
                return RedirectToAction(nameof(AllMessages));
            }

            await messageService.Delete(id);

            return RedirectToAction(nameof(AllMessages), ArtistControllerName);
        }

    }
}
