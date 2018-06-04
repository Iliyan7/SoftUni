using System;
using System.Collections.Generic;
using System.Linq;
using WebServer.Server.Enums;
using WebServer.Server.Handlers;
using WebServer.Server.Routing.Contracts;

namespace WebServer.Server.Routing
{
    public class AppRouteConfig : IAppRouteConfig
    {
        private readonly Dictionary<HttpRequestMethod, IDictionary<string, RequestHandler>> routes;

        public AppRouteConfig()
        {
            this.routes = new Dictionary<HttpRequestMethod, IDictionary<string, RequestHandler>>();

            var methods = Enum
                .GetValues(typeof(HttpRequestMethod))
                .Cast<HttpRequestMethod>();

            foreach (var method in methods)
            {
                this.routes[method] = new Dictionary<string, RequestHandler>();
            }
        }

        public IReadOnlyDictionary<HttpRequestMethod, IDictionary<string, RequestHandler>> Routes => this.routes;

        public void AddRoute(string route, RequestHandler requestHandler)
        {
            var requestName = requestHandler.GetType().Name;
            var method = Enum.Parse<HttpRequestMethod>(requestName.Substring(0, requestName.IndexOf("Handler")));

            this.routes[method].Add(route, requestHandler);
        }
    }
}
