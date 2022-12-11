namespace ShuInkWeb.Areas.Artist.Controllers
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using ShuInkWeb.Core.Contracts;
    using ShuInkWeb.Data.Entities.Identities;
    using ShuInkWeb.Extensions;

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
            var id = await artistService.GetArtistIdAsync(User.Id());

            var models = await appointmentService.GetAppointmentsForCurrentArtist(id);

            return View(models);
        }

        public async Task<IActionResult> AllMessages()
        {
            var models = await messageService.All();

            return View(models);
        }

    }
}
