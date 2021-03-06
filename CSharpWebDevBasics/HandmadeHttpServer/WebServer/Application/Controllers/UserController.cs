﻿using WebServer.Application.Views.User;
using WebServer.Server;
using WebServer.Server.Enums;
using WebServer.Server.Http.Contracts;
using WebServer.Server.Http.Response;

namespace WebServer.Application.Controllers
{
    public class UserController
    {
        public IHttpResponse RegisterGet()
        {
            return new ViewResponse(HttpStatusCode.OK, new RegisterView());
        }

        public IHttpResponse RegisterPost(string name)
        {
            return new RedirectResponse($"/user/{name}");
        }

        public IHttpResponse Details(string name)
        {
            var model = new Model { ["name"] = name };

            return new ViewResponse(HttpStatusCode.OK, new DetailsView(model));
        }
    }
}
