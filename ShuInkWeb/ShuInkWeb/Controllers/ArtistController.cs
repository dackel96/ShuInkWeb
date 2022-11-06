using Microsoft.AspNetCore.Mvc;
using ShuInkWeb.Core.Contracts;

namespace ShuInkWeb.Controllers
{
    public class ArtistController : Controller
    {
        private readonly IArtistService artistService;

        public ArtistController(IArtistService _artistService)
        {
            this.artistService = _artistService;
        }

    }
}
