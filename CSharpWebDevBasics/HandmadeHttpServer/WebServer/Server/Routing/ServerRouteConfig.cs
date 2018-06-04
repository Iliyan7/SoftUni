using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using WebServer.Server.Enums;
using WebServer.Server.Routing.Contracts;

namespace WebServer.Server.Routing
{
    public class ServerRouteConfig : IServerRouteConfig
    {
        private readonly IDictionary<HttpRequestMethod, IDictionary<string, IRoutingContext>> routes;

        public ServerRouteConfig(IAppRouteConfig appRouteConfig)
        {
            this.routes = new Dictionary<HttpRequestMethod, IDictionary<string, IRoutingContext>>();

            var methods = Enum
               .GetValues(typeof(HttpRequestMethod))
               .Cast<HttpRequestMethod>();

            foreach (var method in methods)
            {
                this.routes[method] = new Dictionary<string, IRoutingContext>();

            }

            this.InitializeRouteConfig(appRouteConfig);
        }

        public IDictionary<HttpRequestMethod, IDictionary<string, IRoutingContext>> Routes => this.routes;

        private void InitializeRouteConfig(IAppRouteConfig appRouteConfig)
        {
            foreach (var registeredRoute in appRouteConfig.Routes)
            {
                var requestMethod = registeredRoute.Key;
                var routesWithHandlers = registeredRoute.Value;

                foreach (var routeWithHandler in routesWithHandlers)
                {
                    var route = routeWithHandler.Key;
                    var handler = routeWithHandler.Value;

                    var parameters = new List<string>();

                    var parsedRoute = this.ParseRoute(route, parameters);

                    var routingContext = new RoutingContext(parameters, handler);

                    this.routes[requestMethod].Add(parsedRoute, routingContext);
                }
            }
        }

        private string ParseRoute(string route, List<string> parameters)
        {
            if (route == "/")
            {
                return "^/$";
            }

            var parsedRoute = new StringBuilder();
            parsedRoute.Append("^/");

            var tokens = route
                .Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

            this.ParseTokens(tokens, parameters, parsedRoute);

            return parsedRoute.ToString();
        }

        private void ParseTokens(string[] tokens, List<string> parameters, StringBuilder parsedRoute)
        {
            for (int i = 0; i < tokens.Length; i++)
            {
                var end = i == tokens.Length - 1 ? "$" : "/";
                var currentToken = tokens[i];

                if (!currentToken.StartsWith('{') && !currentToken.EndsWith('}'))
                {
                    parsedRoute.Append($"{currentToken}{end}");
                    continue;
                }

                var parameterMatch = Regex.Match(currentToken, "<\\w+>");

                if (!parameterMatch.Success)
                {
                    continue;
                }

                var match = parameterMatch.Value;
                var parameter = match.Substring(1, match.Length - 2);

                parameters.Add(parameter);

                parsedRoute.Append($"{currentToken.Substring(1, currentToken.Length - 2)}{end}");
            }
        }
    }
}
