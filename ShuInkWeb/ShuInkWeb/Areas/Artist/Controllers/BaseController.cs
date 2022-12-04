using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static ShuInkWeb.Constants.AreaConstants;

namespace ShuInkWeb.Areas.Artist.Controllers
{
    [Area(AreaName)]
    [Route("Artist/[controller]/[action]/{id?}")]
    [Authorize(Roles = RoleName)]
    public class BaseController : Controller
    {
    }
}
