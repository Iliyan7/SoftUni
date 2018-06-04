using WebServer.Server;
using WebServer.Server.Contracts;

namespace WebServer.Application.Views.User
{
    public class DetailsView : IView
    {
        private readonly Model model;

        public DetailsView(Model model)
        {
            this.model = model;
        }

        public string View()
        {
            return $"<body>Hello, {model["name"]}!</body>";
        }
    }
}
