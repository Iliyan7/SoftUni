using WebServer.ByTheCakeApplication.Infrastructure;
using WebServer.Server.Http.Contracts;

namespace WebServer.ByTheCakeApplication.Controllers
{
    public class HomeController : Controller
    {
        public IHttpResponse Index() => this.FileViewResponse(@"home\index");

        public IHttpResponse About() => this.FileViewResponse(@"home\about");
    }
}
