using Data;
using Framework;
using Framework.Routers;
using Microsoft.EntityFrameworkCore;
using WebServer;

namespace MeTube
{
    public class Launcher
    {
        public static void Main()
        {
            using (var db = new MeTubeDbContext())
            {
                db.Database.Migrate();
            }

            var server = new HttpServer(1337, new ControllerRouter(), new ResourceRouter());
            MvcEngine.Run(server);
        }
    }
}
