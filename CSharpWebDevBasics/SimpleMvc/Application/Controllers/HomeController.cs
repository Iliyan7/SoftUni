using Framework.Attributes.Methods;
using Framework.Contracts;
using Framework.Controllers;

namespace Application.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
