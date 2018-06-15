using System;
using WebServer.Server.Enums;

namespace WebServer.Server.Http.Response
{
    public class InternalServerErrorResponse : ViewResponse
    {
        public InternalServerErrorResponse(Exception ex)
            : base(HttpStatusCode.InternalServerError, new InternalServerErrorView(ex))
        {

        }
    }
}
