using WebServer.Application.Views.Home;
using WebServer.Server.Enums;
using WebServer.Server.Http;
using WebServer.Server.Http.Contracts;
using WebServer.Server.Http.Response;

namespace WebServer.Application.Controllers
{
    public class HomeController
    {
        public IHttpResponse Index()
        {
            var response = new ViewResponse(HttpStatusCode.OK, new IndexView());

            response.Cookies.Add(new HttpCookie("lang", "en"));

            return response;
        }

        public IHttpResponse About()
        {
            return new ViewResponse(HttpStatusCode.OK, new AboutView());
        }
    }
}
