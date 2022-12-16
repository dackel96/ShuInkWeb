using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShuInkWeb.Controllers.Common;
using ShuInkWeb.Core.Contracts;
using ShuInkWeb.Core.Models.MerchandiseModels;

namespace ShuInkWeb.Areas.Shop.Controllers
{
    public class MerchandiseController : BaseController
    {
        private readonly IMerchandiseService merchandiseService;


        public MerchandiseController(IMerchandiseService _merchandiseService)
        {
            merchandiseService = _merchandiseService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> All()
        {
            var models = await merchandiseService.GetAllMerchandisesAsync();

            return View(models);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new MerchandiseViewModel();

            model.Types = await merchandiseService.GetMerchandiseTypesAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(MerchandiseViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Types = await merchandiseService.GetMerchandiseTypesAsync();

                return View(model);
            }

            await merchandiseService.AddMerchandiseAsync(model);

            return View();
        }

        //TO DO Add product

        //Edit Product

        //Delete Product
    }
}
