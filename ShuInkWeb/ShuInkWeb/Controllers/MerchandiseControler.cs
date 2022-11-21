using Microsoft.AspNetCore.Mvc;
using ShuInkWeb.Controllers.Common;
using ShuInkWeb.Core.Contracts;
using ShuInkWeb.Core.Models.MerchandiseModels;

namespace ShuInkWeb.Controllers
{
    public class MerchandiseControler : BaseController
    {
        private readonly IMerchandiseService merchandiseService;

        public MerchandiseControler(IMerchandiseService _merchandiseService)
        {
            this.merchandiseService = _merchandiseService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {

            var models = await merchandiseService.GetAllMerchandisesAsync();

            return View(models);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var model = new MerchandiseViewModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(MerchandiseViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await merchandiseService.AddMerchandiseAsync(model);

            return View();
        }
    }
}
