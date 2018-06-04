using System;
using WebServer.Server.Handlers.Contracts;
using WebServer.Server.Http.Contracts;

namespace WebServer.Server.Handlers
{
    public abstract class RequestHandler : IRequestHandler
    {
        private readonly Func<IHttpRequest, IHttpResponse> func;

        protected RequestHandler(Func<IHttpRequest, IHttpResponse> func)
        {
            this.func = func;
        }

        public IHttpResponse Handle(IHttpContext context)
        {
            var httpResponse = this.func(context.Request);

            return httpResponse;
        }
    }
}
