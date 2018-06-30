using Data;
using Framework;
using Framework.Routers;
using Microsoft.EntityFrameworkCore;
using WebServer;

namespace Application
{
    public class Launcher
    {
        public static void Main(string[] args)
        {
            using (var db = new NotesDbContext())
            {
                db.Database.Migrate();
            }

            var server = new HttpServer(1337, new ControllerRouter(), new ResourceRouter());
            MvcEngine.Run(server);
        }
    }
}
