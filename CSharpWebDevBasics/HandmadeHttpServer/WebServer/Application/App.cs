using WebServer.Application.Controllers;
using WebServer.Server.Contracts;
using WebServer.Server.Handlers;
using WebServer.Server.Routing.Contracts;

namespace WebServer.Application
{
    public class App : IApplication
    {
        public void Config(IAppRouteConfig routeConfig)
        {
            routeConfig.AddRoute(
                "/",
                new GetHandler(req => new HomeController().Index()));

            routeConfig.AddRoute(
                "/about",
                new GetHandler(req => new HomeController().About()));

            routeConfig.AddRoute(
                "/register",
                new GetHandler(req => new UserController().RegisterGet()));

            routeConfig.AddRoute(
               "/register",
               new PostHandler(req => new UserController().RegisterPost(req.FormData["name"])));

            routeConfig.AddRoute(
                "/user/{(?<name>[a-z]+)}",
                new GetHandler(req => new UserController().Details(req.UrlParameters["name"])));
        }
    }
}
