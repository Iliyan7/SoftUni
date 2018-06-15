using System.Collections;
using System.Collections.Generic;
using WebServer.Server.Http.Contracts;

namespace WebServer.Server.Http
{
    public class HttpCookieCollection : IHttpCookieCollection
    {
        private readonly IDictionary<string, HttpCookie> cookies;

        public HttpCookieCollection()
        {
            this.cookies = new Dictionary<string, HttpCookie>();
        }

        public void Add(HttpCookie cookie)
        {
            this.cookies[cookie.Key] = cookie;
        }

        public bool ContainsKey(string key) => this.cookies.ContainsKey(key);

        public HttpCookie GetCookie(string key)
        {
            if (!this.cookies.ContainsKey(key))
            {
                throw new KeyNotFoundException();
            }

            return this.cookies[key];
        }

        public IEnumerator<HttpCookie> GetEnumerator()
        {
            return this.cookies.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.cookies.Values.GetEnumerator();
        }
    }
}
