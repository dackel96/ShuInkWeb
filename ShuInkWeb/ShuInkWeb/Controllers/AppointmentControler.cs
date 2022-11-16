using Microsoft.AspNetCore.Mvc;
using ShuInkWeb.Controllers.Common;
using ShuInkWeb.Core.Contracts;
using ShuInkWeb.Core.Models.AppointmentModels;
using ShuInkWeb.Extensions;

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

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var model = appointmentService.FindByIdAsync(id);

            if (model == null)
            {
                return BadRequest();
            }

            if (await artistService.ExistArtist(User.Id()))
            {
                return Unauthorized();
            }

            AppointmentViewModel viewModel = new AppointmentViewModel()
            
        }

        [HttpPost]
        public async Task<IActionResult> Edit()
        {

        }
    }
}
