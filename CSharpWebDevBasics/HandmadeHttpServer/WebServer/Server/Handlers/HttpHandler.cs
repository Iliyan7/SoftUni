using System;
using System.Linq;
using System.Text.RegularExpressions;
using WebServer.Server.Handlers.Contracts;
using WebServer.Server.Http;
using WebServer.Server.Http.Contracts;
using WebServer.Server.Http.Response;
using WebServer.Server.Routing.Contracts;

namespace WebServer.Server.Handlers
{
    public class HttpHandler : IRequestHandler
    {
        private readonly IServerRouteConfig serverRouteConfig;

        public HttpHandler(IServerRouteConfig serverRouteConfig)
        {
            this.serverRouteConfig = serverRouteConfig;
        }

        public IHttpResponse Handle(IHttpContext context)
        {
            try
            {
                var anonymousPaths = new string[] { "/login", "/register" };

                if (anonymousPaths.Contains(context.Request.Path) && 
                    (context.Request.Session == null || !context.Request.Session.Contains(SessionStorage.CurrentUserKey)))
                {
                    return new RedirectResponse(anonymousPaths.First());
                }

                var requestMethod = context.Request.Method;
                var requestPath = context.Request.Path;
                var registeredRoutes = this.serverRouteConfig.Routes[requestMethod];

                foreach (var registeredRoute in registeredRoutes)
                {
                    var routePattern = registeredRoute.Key;
                    var routingContext = registeredRoute.Value;

                    var match = Regex.Match(requestPath, routePattern);

                    if (!match.Success)
                    {
                        continue;
                    }

                    var parameters = routingContext.Parameters;

                    foreach (var parameter in parameters)
                    {
                        var parameterValue = match.Groups[parameter].Value;
                        context.Request.AddUrlParameter(parameter, parameterValue);
                    }

                    return routingContext.Handler.Handle(context);
                }
            }
            catch (Exception ex)
            {
                return new InternalServerErrorResponse(ex);
            }
           
            return new NotFoundResponse();
        }
    }
}
