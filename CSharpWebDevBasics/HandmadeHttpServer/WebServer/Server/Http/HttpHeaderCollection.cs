using System;
using System.Collections.Generic;
using System.Text;
using WebServer.Server.Http.Contracts;

namespace WebServer.Server.Http
{
    public class HttpHeaderCollection : IHttpHeaderCollection
    {
        private readonly IDictionary<string, ICollection<HttpHeader>> headers;
        
        public HttpHeaderCollection()
        {
            this.headers = new Dictionary<string, ICollection<HttpHeader>>();
        }

        public void Add(HttpHeader header)
        {
            var key = header.Key;

            if(!this.headers.ContainsKey(key))
            {
                this.headers[key] = new List<HttpHeader>();
            }

            this.headers[key].Add(header);
        }

        public void Add(string key, string value)
        {
            this.Add(new HttpHeader(key, value));
        }

        public bool ContainsKey(string key) => this.headers.ContainsKey(key);

        public ICollection<HttpHeader> GetHeaders(string key)
        {
            if(!this.headers.ContainsKey(key))
            {
                throw new KeyNotFoundException();
            }

            return this.headers[key];
        }

        public override string ToString()
        {
            var headersString = new StringBuilder();

            foreach (var headers in this.headers.Values)
            {
                headersString.AppendLine(string.Join(Environment.NewLine, headers));
            }

            return headersString.ToString();
        }
    }
}
