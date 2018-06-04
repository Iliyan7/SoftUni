using System;
using WebServer.Server.Http.Contracts;

namespace WebServer.Server.Handlers
{
    public class GetHandler : RequestHandler
    {
        public GetHandler(Func<IHttpRequest, IHttpResponse> func) 
            : base(func)
        {
        }
    }
}
