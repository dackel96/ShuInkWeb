using Microsoft.AspNetCore.Mvc;
using ShuInkWeb.Core.Contracts;
using ShuInkWeb.Core.Models.AppointmentModels;

namespace ShuInkWeb.Controllers
{
    public class AppointmentController : BaseController
    {
        private readonly IAppointmentService appointmentService;

        public AppointmentController(IAppointmentService _appointmentService)
        {
            appointmentService = _appointmentService;
        }

        public IActionResult All()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            var model = new AddAppointmentViewModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddAppointmentViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await appointmentService.AddAppointmentAsync(model);

                return RedirectToAction(nameof(All));
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Not Valid!");

                return View(model);
            }
        }
    }
}
