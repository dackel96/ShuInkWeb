using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShuInkWeb.Controllers.Common;
using ShuInkWeb.Core;
using ShuInkWeb.Core.Contracts;
using ShuInkWeb.Core.Models.AppointmentModels;
using ShuInkWeb.Core.Models.ClientModels;
using ShuInkWeb.Data.Entities.Clients;
using ShuInkWeb.Extensions;
using ShuInkWeb.JsonSerializer;

namespace ShuInkWeb.Controllers
{
    public class AppointmentController : BaseController
    {
        private readonly INotyfService toastNotification;

        private readonly IAppointmentService appointmentService;

        private readonly IArtistService artistService;

        private readonly IJsonCalendarListEvents jsonSerializer;

        private readonly IClientService clientService;

        public AppointmentController(IAppointmentService _appointmentService,
                                     IArtistService _artistService,
                                     INotyfService _toastNotification,
                                     IJsonCalendarListEvents _jsonSerializer,
                                     IClientService _clientService)
        {
            appointmentService = _appointmentService;
            artistService = _artistService;
            toastNotification = _toastNotification;
            jsonSerializer = _jsonSerializer;
            this.clientService = _clientService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var models = await appointmentService.GetAppointmentsForTodayAsync();

            return View(models);
        }

        [HttpGet]
        public IActionResult AllForMonth()
        {
            ViewData["Events"] = jsonSerializer.GetEventListJSONString();

            ViewData["Resources"] = jsonSerializer.GetResourceListJSONString();

            return View();
        }

        [HttpGet]
        [Authorize(Roles = "Artist")]
        public async Task<IActionResult> Add()
        {
            if (!(await artistService.ExistById(User.Id())))
            {
                return RedirectToAction("Index", "Home");
            }

            var model = new AppointmentViewModel();


            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Artist")]
        public async Task<IActionResult> Add(AppointmentViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            Guid artistId = await artistService.GetArtistIdAsync(User.Id());

            await appointmentService.AddAppointmentAsync(model, artistId);

            return RedirectToAction(nameof(All));
        }


        public async Task<IActionResult> Details(Guid id)
        {
            if ((await appointmentService.Exists(id)) == false)
            {
                toastNotification.Error("This Appointment doe's not exist");

                return RedirectToAction(nameof(All));
            }

            var model = await appointmentService.AppointmentInfoModelById(id);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            if ((await appointmentService.Exists(id)) == false)
            {
                toastNotification.Error("This Appointment doe's not exist");

                return RedirectToAction(nameof(All));
            }

            var appointment = await appointmentService.GetAppointmentById(id);

            var client = await clientService.GetClientById(appointment.ClientId);

            int duration = appointment.End.Hour - appointment.Start.Hour;

            var model = new AppointmentViewModel()
            {
                Id = appointment.Id,
                Title = appointment.Title,
                Description = appointment.Description,
                Start = appointment.Start,
                Duration = duration,
                FirstName = client.FirstName,
                LastName = client.LastName,
                PhoneNumber = client.PhoneNumber,
                SocialMedia = client.SocialMedia
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, AppointmentViewModel model)
        {
            if (id != model.Id)
            {
                return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
            }
            if ((await appointmentService.Exists(id)) == false)
            {
                toastNotification.Error("This Appointment doe's not exist");

                return RedirectToAction(nameof(All));
            }
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await appointmentService.Edit(id, model);

            return RedirectToAction(nameof(Details), id);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            await appointmentService.DeleteAppointment(id);

            return RedirectToAction(nameof(All));
        }
    }
}
