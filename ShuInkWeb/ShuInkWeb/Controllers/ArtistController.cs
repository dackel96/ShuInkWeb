using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShuInkWeb.Controllers.Common;
using ShuInkWeb.Core.Contracts;
using ShuInkWeb.Core.Models.ArtistModels;

namespace ShuInkWeb.Controllers
{
    public class ArtistController : BaseController
    {
        private readonly IArtistService artistService;

        public ArtistController(IArtistService _artistService)
        {
            this.artistService = _artistService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> About()
        {
            var model = await artistService.ArtistsInfo();
            return View(model);
        }
    }
}
