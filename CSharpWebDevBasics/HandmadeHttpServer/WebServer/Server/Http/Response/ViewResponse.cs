using WebServer.Server.Contracts;
using WebServer.Server.Enums;

namespace WebServer.Server.Http.Response
{
    public class ViewResponse : HttpResponse
    {
        private readonly IView view;

        public ViewResponse(HttpStatusCode statusCode, IView view) 
        {
            this.StatusCode = statusCode;
            this.view = view;

            this.Headers.Add(new HttpHeader("Content-Type", "text/html"));
        }

        public override string ToString()
        {
            return $"{base.ToString()}{this.view.View()}";
        }
    }
}
