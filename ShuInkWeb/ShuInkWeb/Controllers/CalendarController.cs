using Microsoft.AspNetCore.Mvc;

namespace ShuInkWeb.Controllers
{
    public class CalendarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Calendar()
        {
            return View();
        }
    }
}
