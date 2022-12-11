using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static ShuInkWeb.Constants.AreaConstants;

namespace ShuInkWeb.Areas.Artist.Controllers
{
    [Area(ArtistAreaName)]
    [Route("Artist/[controller]/[action]/{id?}")]
    [Authorize(Roles = ArtistRoleName)]
    public class BaseController : Controller
    {
    }
}
