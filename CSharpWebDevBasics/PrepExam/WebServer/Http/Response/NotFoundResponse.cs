using WebServer.Enums;
using WebServer.Views;

namespace WebServer.Http.Response
{
    public class NotFoundResponse : ContentResponse
    {
        public NotFoundResponse()
            : base(HttpStatusCode.NotFound, new NotFoundView().View())
        {
            this.StatusCode = HttpStatusCode.NotFound;
        }
    }
}
