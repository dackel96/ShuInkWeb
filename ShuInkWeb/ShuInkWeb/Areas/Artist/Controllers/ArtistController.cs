using Microsoft.AspNetCore.Mvc;

namespace ShuInkWeb.Areas.Artist.Controllers
{
    public class ArtistController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
