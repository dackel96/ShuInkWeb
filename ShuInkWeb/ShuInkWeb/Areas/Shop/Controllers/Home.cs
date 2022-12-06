using Microsoft.AspNetCore.Mvc;

namespace ShuInkWeb.Areas.Shop.Controllers
{
    [Area("Shop")]
    [Route("Shop/[controller]/[action]/{id?}")]
    public class Home : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
