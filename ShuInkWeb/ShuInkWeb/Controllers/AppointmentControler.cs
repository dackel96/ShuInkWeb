namespace ShuInkWeb.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using ShuInkWeb.Controllers.Common;
    using ShuInkWeb.Core.Contracts;
    using ShuInkWeb.Core.Models.AppointmentModels;
    using ShuInkWeb.Extensions;
    using ShuInkWeb.JsonSerializer;

    public class AppointmentController : BaseController
    {
        private readonly IAppointmentService appointmentService;

        private readonly IArtistService artistService;

        private readonly IJsonCalendarListEvents jsonSerializer;

        private readonly IClientService clientService;

        public AppointmentController(IAppointmentService _appointmentService,
                                     IArtistService _artistService,
                                     IJsonCalendarListEvents _jsonSerializer,
                                     IClientService _clientService)
        {
            appointmentService = _appointmentService;
            artistService = _artistService;
            jsonSerializer = _jsonSerializer;
            this.clientService = _clientService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var models = await appointmentService.GetAllAsync();

            return View(models);
        }

        [HttpGet]
        [AllowAnonymous]
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

            await appointmentService.AddAsync(model, artistId);

            return RedirectToAction(nameof(All));
        }


        public async Task<IActionResult> Details(Guid id)
        {
            if ((await appointmentService.IsExistingAsync(id)) == false)
            {
                return RedirectToAction(nameof(All));
            }

            var model = await appointmentService.DetailsModelByIdAsync(id);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            if ((await appointmentService.IsExistingAsync(id)) == false)
            {
                return RedirectToAction(nameof(All));
            }

            var appointment = await appointmentService.GetEntityByIdAsync(id);

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
            if ((await appointmentService.IsExistingAsync(id)) == false)
            {
                return RedirectToAction(nameof(All));
            }
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await appointmentService.EditAsync(id, model);

            return RedirectToAction(nameof(Details), id);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            await appointmentService.DeleteAsync(id);

            return RedirectToAction(nameof(All));
        }
    }
}
