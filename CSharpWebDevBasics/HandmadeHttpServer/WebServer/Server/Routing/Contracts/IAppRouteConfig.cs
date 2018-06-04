using System.Collections.Generic;
using WebServer.Server.Enums;
using WebServer.Server.Handlers;

namespace WebServer.Server.Routing.Contracts
{
    public interface IAppRouteConfig
    {
        IReadOnlyDictionary<HttpRequestMethod, IDictionary<string, RequestHandler>> Routes { get; }

        void AddRoute(string route, RequestHandler requestHandler);
    }
}
