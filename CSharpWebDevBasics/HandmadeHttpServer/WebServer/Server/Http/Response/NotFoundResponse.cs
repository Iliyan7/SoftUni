using WebServer.Server.Enums;

namespace WebServer.Server.Http.Response
{
    public class NotFoundResponse : HttpResponse
    {
        public NotFoundResponse()
        {
            this.StatusCode = HttpStatusCode.NotFound;
        }
    }
}
