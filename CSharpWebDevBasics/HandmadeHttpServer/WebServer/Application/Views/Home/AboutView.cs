using WebServer.Server.Contracts;

namespace WebServer.Application.Views.Home
{
    public class AboutView : IView
    {
        public string View()
        {
            return "<body>About Page!</body>";
        }
    }
}
