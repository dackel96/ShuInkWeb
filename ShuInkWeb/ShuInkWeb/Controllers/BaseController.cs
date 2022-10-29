using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ShuInkWeb.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
       
    }
}
