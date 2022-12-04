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

        public ArtistController(IAppointmentService _appointmentService, UserManager<ApplicationUser> _userManager, IArtistService _artistService)
        {
            appointmentService = _appointmentService;
            userManager = _userManager;
            artistService = _artistService;
        }

        public async Task<IActionResult> Index()
        {
            var id = await artistService.GetArtistIdAsync(User.Id());

            var models = await appointmentService.GetAppointmentsForCurrentArtist(id);

            return View(models);
        }
    }
}
