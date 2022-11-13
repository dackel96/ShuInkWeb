using Microsoft.AspNetCore.Mvc;
using ShuInkWeb.Controllers.Common;
using ShuInkWeb.Core.Contracts;
using ShuInkWeb.Core.Models.AppointmentModels;

namespace ShuInkWeb.Controllers
{
    public class AppointmentController : BaseController
    {
        private readonly IAppointmentService appointmentService;

        private readonly IArtistService artistService;

        public AppointmentController(IAppointmentService _appointmentService,
                                     IArtistService _artistService)
        {
            appointmentService = _appointmentService;
            artistService = _artistService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var models = await appointmentService.GetAppointmentsAsync();

            return View(models);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var model = new AppointmentViewModel();

            model.Artists = await artistService.GetArtistsIdAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AppointmentViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await appointmentService.AddAppointmentAsync(model);

            return RedirectToAction(nameof(All));
        }
    }
}
