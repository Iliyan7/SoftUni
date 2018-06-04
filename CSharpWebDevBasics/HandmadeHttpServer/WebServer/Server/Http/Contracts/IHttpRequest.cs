using System.Collections.Generic;
using WebServer.Server.Enums;

namespace WebServer.Server.Http.Contracts
{
    public interface IHttpRequest
    {
        HttpRequestMethod Method { get; }

        string Url { get; }

        string Path { get; }

        IDictionary<string, string> UrlParameters { get; }

        IDictionary<string, string> QueryParameters { get; }

        IHttpHeaderCollection Headers { get; }

        IDictionary<string, string> FormData { get; }

        void AddUrlParameter(string key, string value);
    }
}
