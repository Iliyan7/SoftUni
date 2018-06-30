using System;
using System.Text;
using System.Text.RegularExpressions;
using WebServer.Enums;
using WebServer.Http.Contracts;

namespace WebServer.Http.Response
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
            response.AppendLine($"HTTP/1.1 {(int)this.StatusCode} {this.StatusCodeMessage()}");
            response.AppendLine(this.Headers.ToString());

            return response.ToString();
        }

        private string StatusCodeMessage()
        {
            if(this.StatusCode == HttpStatusCode.OK)
            {
                return "OK";
            }

            var rgx = new Regex("(?<!^)([A-Z])");
            var result = rgx.Replace(this.StatusCode.ToString(), " $1");
            return result;
        }
    }
}
