using WebServer.Application;
using WebServer.Server;
using WebServer.Server.Contracts;
using WebServer.Server.Routing;
using WebServer.Server.Routing.Contracts;

namespace WebServer
{
    public class Launcher : IRunnable
    {
        public static void Main()
        {
            new Launcher().Run();
        }

        public void Run()
        {
            IApplication app = new App();
            IAppRouteConfig routeConfig = new AppRouteConfig();
            app.Config(routeConfig);

            var webServer = new IISWebServer(1337, routeConfig);
            webServer.Run();
        }
    }
}
