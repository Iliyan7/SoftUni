using System.Collections.Generic;

namespace WebServer.Http.Contracts
{
    public interface IHttpCookieCollection : IEnumerable<HttpCookie>
    {
        void Add(HttpCookie cookie);

        bool ContainsKey(string key);

        HttpCookie GetCookie(string key);
    }
}
