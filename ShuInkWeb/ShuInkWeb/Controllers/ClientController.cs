using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ShuInkWeb.Controllers.Common;
using ShuInkWeb.Core.Contracts;
using ShuInkWeb.Data.Entities.Identities;
using ShuInkWeb.Extensions;
using static ShuInkWeb.Constants.ActionsConstants;
using static ShuInkWeb.Constants.AreaConstants;

namespace ShuInkWeb.Controllers
{
    public class ClientController : BaseController
    {
        private readonly IClientService clientService;

        private readonly UserManager<ApplicationUser> userManager;

        public ClientController(IClientService _clientService, UserManager<ApplicationUser> _userManager)
        {
            clientService = _clientService;

            userManager = _userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Mine()
        {
            var userId = await clientService.GetClientByUserId(User.Id());

            var models = await clientService.GetCurrUserAppointments(userId);

            if (!(models.Any()))
            {
                return RedirectToAction(IndexConst, HomeConst);
            }

            return View(models);
        }
    }
}
