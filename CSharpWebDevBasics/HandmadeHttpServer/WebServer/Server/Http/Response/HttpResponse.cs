using System.Text;
using WebServer.Server.Enums;
using WebServer.Server.Http.Contracts;

namespace WebServer.Server.Http.Response
{
    public abstract class HttpResponse : IHttpResponse
    {
        protected HttpResponse()
        {
            this.Headers = new HttpHeaderCollection();
            this.Cookies = new HttpCookieCollection();
        }

        public HttpStatusCode StatusCode { get; protected set; }

        public IHttpHeaderCollection Headers { get; }

        public IHttpCookieCollection Cookies { get; }

        public override string ToString()
        {
            var response = new StringBuilder();
            response.AppendLine($"HTTP/1.1 {(int)this.StatusCode} {this.StatusCode.ToString()}");
            response.AppendLine(this.Headers.ToString());

            return response.ToString();
        }
    }
}
