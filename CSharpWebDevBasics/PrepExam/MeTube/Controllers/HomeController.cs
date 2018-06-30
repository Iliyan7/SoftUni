using Framework.Attributes.Methods;
using Framework.Contracts;

namespace MeTube.Controllers
{
    public class HomeController : BaseController
    {
        [HttpGet]
        public IActionResult Index()
        {
            if (this.User.IsAuthenticated)
            {
                return this.RedirectToAction(LoggedInHomePage);
            }

            return View();
        }
    }
}
