using WebServer.Server.Contracts;

namespace WebServer.Application.Views.Home
{
    public class IndexView : IView
    {
        public string View()
        {
            return "<body><h1>Welcome</h1></body>";
        }
    }
}
