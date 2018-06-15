using Framework;
using Framework.Routers;
using WebServer;

namespace Application
{
    public class Launcher
    {
        public static void Main(string[] args)
        {
            var server = new HttpServer(1337, new ControllerRouter());
            MvcEngine.Run(server);
        }
    }
}
