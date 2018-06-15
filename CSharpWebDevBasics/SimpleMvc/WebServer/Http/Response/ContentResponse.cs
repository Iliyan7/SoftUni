using WebServer.Enums;

namespace WebServer.Http.Response
{
    public class ContentResponse : HttpResponse
    {
        private readonly string content;

        public ContentResponse(HttpStatusCode statusCode, string content) 
        {
            this.StatusCode = statusCode;
            this.content = content;

            this.Headers.Add(new HttpHeader("Content-Type", "text/html"));
        }

        public override string ToString()
        {
            return $"{base.ToString()}{this.content}";
        }
    }
}
