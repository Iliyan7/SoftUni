using System;
using Microsoft.EntityFrameworkCore;
using WebServer.ByTheCakeApplication.Controllers;
using WebServer.ByTheCakeApplication.Data;
using WebServer.ByTheCakeApplication.ViewModels.Account;
using WebServer.ByTheCakeApplication.ViewModels.Products;
using WebServer.Server.Contracts;
using WebServer.Server.Handlers;
using WebServer.Server.Routing.Contracts;

namespace WebServer.ByTheCakeApplication
{
    public class ByTheCakeApp : IApplication
    {
        public void InitializeDatabase()
        {
            using (var db = new ByTheCakeDbContext())
            {
                db.Database.Migrate();
            }
        }

        public void Config(IAppRouteConfig routeConfig)
        {
            routeConfig.AddRoute(
                "/",
                new GetHandler(req => new HomeController().Index()));

            routeConfig.AddRoute(
                "/about",
                new GetHandler(req => new HomeController().About()));

            RegisterAccountControllerRoutes(routeConfig);
            RegisterProductsControllerRoutes(routeConfig);
            RegisterShoppingControllerRoutes(routeConfig);
        }

        private void RegisterAccountControllerRoutes(IAppRouteConfig routeConfig)
        {
            routeConfig.AddRoute("/register", new GetHandler(req => new AccountController().Register()));
            routeConfig.AddRoute("/register", new PostHandler(req => new AccountController().Register(req,
                new RegisterUserViewModel
                {
                    Username = req.FormData["username"],
                    Password = req.FormData["password"],
                    ConfirmPassword = req.FormData["confirm-password"]
                })));

            routeConfig.AddRoute("/login", new GetHandler(req => new AccountController().Login()));
            routeConfig.AddRoute("/login", new PostHandler(req => new AccountController().Login(req,
                new LoginViewModel
                {
                    Username = req.FormData["username"],
                    Password = req.FormData["password"]
                })));

            routeConfig.AddRoute("/profile", new GetHandler(req => new AccountController().Profile(req)));

            routeConfig.AddRoute("/logout", new PostHandler(req => new AccountController().Logout(req)));
        }

        private void RegisterProductsControllerRoutes(IAppRouteConfig routeConfig)
        {
            routeConfig.AddRoute(
                "/add",
                new GetHandler(req => new ProductsController().Add()));

            routeConfig.AddRoute(
                "/add",
                new PostHandler(req => new ProductsController().Add(
                    new AddProductViewModel
                    {
                        Name = req.FormData["name"],
                        Price = decimal.Parse(req.FormData["price"]),
                        ImageUrl = req.FormData["imageUrl"]
                    })));

            routeConfig.AddRoute(
                "/search",
                new GetHandler(req => new ProductsController().Search(req)));

            routeConfig.AddRoute(
                "/cakes/{(?<id>[0-9]+)}",
                new GetHandler(req => new ProductsController().Details(int.Parse(req.UrlParameters["id"]))));
        }

        private void RegisterShoppingControllerRoutes(IAppRouteConfig routeConfig)
        {
            routeConfig.AddRoute(
                "/shopping/add/{(?<id>[0-9]+)}",
                new GetHandler(req => new ShoppingController().AddToCart(req)));

            routeConfig.AddRoute(
                "/cart",
                new GetHandler(req => new ShoppingController().ShowCart(req)));

            routeConfig.AddRoute(
                "/shopping/finish-order",
                new PostHandler(req => new ShoppingController().FinishOrder(req)));
        }
    }
}
