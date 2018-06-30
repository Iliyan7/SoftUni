using System;
using WebServer.Enums;
using WebServer.Views;

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
