using WebServer.Application;
using WebServer.ByTheCakeApplication;
using WebServer.Server;
using WebServer.Server.Contracts;
using WebServer.Server.Routing;
using WebServer.Server.Routing.Contracts;

namespace WebServer
{
    public class Launcher
    {
        public static void Main()
        {
            Run();
        }

        private static void Run()
        {
            var app = new ByTheCakeApp();
            app.InitializeDatabase();

            var routeConfig = (IAppRouteConfig)new AppRouteConfig();
            app.Config(routeConfig);

            var webServer = new HttpServer(1337, routeConfig);
            webServer.Run();
        }
    }
}
