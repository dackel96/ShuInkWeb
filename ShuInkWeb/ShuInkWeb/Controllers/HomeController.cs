using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShuInkWeb.Controllers.Common;
using static ShuInkWeb.Constants.AreaConstants;
using static ShuInkWeb.Constants.ActionsConstants;

namespace ShuInkWeb.Controllers
{
    public class HomeController : BaseController
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            if (User.IsInRole(ArtistRoleName))
            {
                return RedirectToAction(IndexConst, ArtistRoleName, new { area = ArtistAreaName });
            }
            return View();
        }

        //TO DO Interface of HomePage
    }
}