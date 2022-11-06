using Microsoft.AspNetCore.Mvc;
using ShuInkWeb.Core.Contracts;
using ShuInkWeb.Core.Models.ArtistModels;

namespace ShuInkWeb.Controllers
{
    public class ArtistController : Controller
    {
        private readonly IArtistService artistService;

        public ArtistController(IArtistService _artistService)
        {
            this.artistService = _artistService;
        }

        [HttpGet]
        public IActionResult About()
        {
            var model = new ArtistViewModel();

            return View();
        }
    }
}
