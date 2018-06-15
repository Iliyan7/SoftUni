using System;
using WebServer.Common;
using WebServer.Enums;

namespace WebServer.Http.Response
{
    public class InternalServerErrorResponse : ContentResponse
    {
        public InternalServerErrorResponse(Exception ex)
            : base(HttpStatusCode.InternalServerError, new InternalServerErrorView(ex).View())
        {
        }
    }
}
