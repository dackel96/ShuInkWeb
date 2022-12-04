using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ShuInkWeb.Areas.Artist.Controllers
{
    [Area("Artist")]
    [Route("Artist/[controller]/[action]/{id?}")]
    [Authorize(Roles = "Artist")]
    public class BaseController : Controller
    {
    }
}
