using System.Collections.Generic;
using WebServer.Server.Handlers;
using WebServer.Server.Routing.Contracts;

namespace WebServer.Server.Routing
{
    public class RoutingContext : IRoutingContext
    {
        public RoutingContext(IEnumerable<string> parameters, RequestHandler handler)
        {
            this.Parameters = parameters;
            this.Handler = handler;

        }

        public IEnumerable<string> Parameters { get; private set; }

        public RequestHandler Handler { get; private set; }
    }
}
