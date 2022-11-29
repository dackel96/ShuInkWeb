using Microsoft.AspNetCore.Mvc;
using ShuInkWeb.Controllers.Common;
using ShuInkWeb.Core;
using ShuInkWeb.Core.Contracts;
using ShuInkWeb.Core.Models.AppointmentModels;
using ShuInkWeb.Extensions;
using ShuInkWeb.JsonSerializer;

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
        public async Task<IActionResult> AllForToday()
        {
            var models = await appointmentService.GetAppointmentsForTodayAsync();

            return View(models);
        }

        [HttpGet]
        public async Task<IActionResult> AllForMonth()
        {
            ViewData["Events"] = JsonCalendarListEvents.GetEventListJSONString(await appointmentService.GetAllAppointments());

            ViewData["Resources"] = JsonCalendarListEvents.GetResourceListJSONString(await artistService.GetArtistsIdAsync());

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            if (!(await artistService.ExistById(User.Id())))
            {
                TempData[MessageConstant.ErrorMessage] = "Зада запазите час трябва да сте Артист!";
                return RedirectToAction("Index", "Home");
            }

            var model = new AppointmentViewModel();

            model.Artists = await artistService.GetArtistsIdAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AppointmentViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await appointmentService.AddAppointmentAsync(model);

            return RedirectToAction(nameof(AllForToday));
        }

        //[HttpGet]
        //public async Task<IActionResult> Edit(Guid id)
        //{
        //    if (!(await appointmentService.Exists(id)))
        //    {
        //        return RedirectToAction(nameof(All));
        //    }

        //    if (!(await appointmentService.HasArtistWithId(id, User.Id())))
        //    {
        //        return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
        //    }

        //}

        //[HttpPost]
        //public async Task<IActionResult> Edit(AppointmentViewModel model)
        //{

        //}
        //TO DO Remove
    }
}
