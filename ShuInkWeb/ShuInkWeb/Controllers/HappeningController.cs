using Microsoft.AspNetCore.Mvc;
using ShuInkWeb.Core.Contracts;

namespace ShuInkWeb.Controllers
{
    public class HappeningController : Controller
    {
        private readonly IHappeningService happeningService;

        public HappeningController(IHappeningService _happeningService)
        {
            this.happeningService = _happeningService;
        }

        public IActionResult All()
        {

            return View();
        }
    }
}
