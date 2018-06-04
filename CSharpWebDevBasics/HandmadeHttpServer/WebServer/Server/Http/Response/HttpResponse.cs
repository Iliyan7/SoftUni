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
        }

        public HttpStatusCode StatusCode { get; protected set; }

        public IHttpHeaderCollection Headers { get; }

        private string StatusCodeMessage => this.StatusCode.ToString();

        public override string ToString()
        {
            var response = new StringBuilder();
            response.AppendLine($"HTTP/1.1 {(int)this.StatusCode} {this.StatusCodeMessage}");
            response.AppendLine(this.Headers.ToString());
            response.AppendLine();

            return response.ToString();
        }
    }
}
