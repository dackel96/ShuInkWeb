using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ShuInkWeb.Controllers.Common
{
    [Authorize]
    public class BaseController : Controller
    {
    }
}
