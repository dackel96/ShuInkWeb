using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShuInkWeb.Controllers.Common;
using ShuInkWeb.Core.Contracts;
using ShuInkWeb.Core.Models.AppointmentModels;
using ShuInkWeb.Extensions;
using ShuInkWeb.JsonSerializer;

using static ShuInkWeb.Constants.AreaConstants;
using static ShuInkWeb.Constants.AppointmentControllerConstants;
using static ShuInkWeb.Constants.ActionsConstants;

namespace ShuInkWeb.Controllers
{
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
            clientService = _clientService;
        }

        [HttpGet]
        [Authorize(Roles = ArtistRoleName)]
        public async Task<IActionResult> All()
        {
            var models = await appointmentService.GetAllAsync();

            return View(models);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult AllForMonth()
        {
            ViewData[EventsConst] = jsonSerializer.GetEventListJSONString();

            ViewData[ResourceConst] = jsonSerializer.GetResourceListJSONString();

            return View();
        }

        [HttpGet]
        [Authorize(Roles = ArtistRoleName)]
        public async Task<IActionResult> Add()
        {
            if (!(await artistService.ExistByIdAsync(User.Id())))
            {
                return RedirectToPage(InvalidOperation, new { area = IdentityRoleName });
            }

            if (!(User.IsInRole(ArtistRoleName)))
            {
                return RedirectToPage(InvalidOperation, new { area = IdentityRoleName });
            }

            var model = new AppointmentViewModel();


            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = ArtistRoleName)]
        public async Task<IActionResult> Add(AppointmentViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (!(await artistService.ExistByIdAsync(User.Id())))
            {
                return RedirectToPage(InvalidOperation, new { area = IdentityRoleName });
            }

            if (!(User.IsInRole(ArtistRoleName)))
            {
                return RedirectToPage(InvalidOperation, new { area = IdentityRoleName });
            }

            Guid artistId = await artistService.GetArtistIdAsync(User.Id());

            await appointmentService.AddAsync(model, artistId);

            return RedirectToAction(IndexConst,HomeConst);
        }

        [Authorize(Roles = ArtistRoleName)]
        public async Task<IActionResult> Details(Guid id)
        {
            if ((await appointmentService.IsExistingAsync(id)) == false)
            {
                return RedirectToAction(nameof(All));
            }

            if (!(await artistService.ExistByIdAsync(User.Id())))
            {
                return RedirectToPage(InvalidOperation, new { area = IdentityRoleName });
            }

            if (!(User.IsInRole(ArtistRoleName)))
            {
                return RedirectToPage(InvalidOperation, new { area = IdentityRoleName });
            }

            var model = await appointmentService.DetailsModelByIdAsync(id);

            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = ArtistRoleName)]
        public async Task<IActionResult> Edit(Guid id)
        {
            if ((await appointmentService.IsExistingAsync(id)) == false)
            {
                return RedirectToAction(nameof(All));
            }

            if (!(User.IsInRole(ArtistRoleName)))
            {
                return RedirectToPage(InvalidOperation, new { area = IdentityRoleName });
            }

            var appointment = await appointmentService.GetEntityByIdAsync(id);

            var client = await clientService.GetClientById(appointment.ClientId);

            if (client == null)
            {
                return RedirectToAction(nameof(All));
            }

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
        [Authorize(Roles = ArtistRoleName)]
        public async Task<IActionResult> Edit(Guid id, AppointmentViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (id != model.Id)
            {
                return RedirectToPage(InvalidOperation, new { area = IdentityRoleName });
            }

            if ((await appointmentService.IsExistingAsync(id)) == false)
            {
                return RedirectToAction(nameof(All));
            }

            if (!(User.IsInRole(ArtistRoleName)))
            {
                return RedirectToPage(InvalidOperation, new { area = IdentityRoleName });
            }

            await appointmentService.EditAsync(id, model);

            return RedirectToAction(nameof(Details), id);
        }

        [Authorize(Roles = ArtistRoleName)]
        public async Task<IActionResult> Delete(Guid id)
        {
            if ((await appointmentService.IsExistingAsync(id)) == false)
            {
                return RedirectToAction(nameof(All));
            }

            if (!(User.IsInRole(ArtistRoleName)))
            {
                return RedirectToPage(InvalidOperation, new { area = IdentityRoleName });
            }

            await appointmentService.DeleteAsync(id);

            return RedirectToAction(nameof(All));
        }
    }
}
