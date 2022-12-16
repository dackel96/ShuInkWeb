using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using static ShuInkWeb.Constants.AreaConstants;

namespace ShuInkWeb.Areas.Shop.Controllers
{
    [Area(ShopAreaName)]
    [Route("Shop/[controller]/[action]/{id?}")]
    [Authorize(Roles = AdminRoleName)]
    public class BaseController : Controller
    {
    }
}
