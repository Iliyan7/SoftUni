using System;
using WebServer.Server.Handlers.Contracts;
using WebServer.Server.Http;
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
            string sessionIdToSend = null;

            if (!context.Request.Cookies.ContainsKey(SessionStorage.SessionKey))
            {
                var sessionId = Guid.NewGuid().ToString();

                context.Request.Session = SessionStorage.GetSession(sessionId);

                sessionIdToSend = sessionId;
            }

            var httpResponse = this.func(context.Request);

            if (sessionIdToSend != null)
            {
                httpResponse.Headers.Add("Set-Cookie", $"{SessionStorage.SessionKey}={sessionIdToSend}; HttpOnly; path=/");
            }

            foreach (var cookie in httpResponse.Cookies)
            {
                httpResponse.Headers.Add("Set-Cookie", cookie.ToString());
            }

            return httpResponse;
        }
    }
}
