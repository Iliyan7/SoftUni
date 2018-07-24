using Microsoft.EntityFrameworkCore;
using SoftUni.App.Data;
using SoftUni.App.Models;
using SoftUni.WebServer.Mvc;
using SoftUni.WebServer.Mvc.Routers;
using System;
using System.Collections.Generic;

namespace SoftUni.App.Chushka
{
    public class Launcher
    {
        public static void Main()
        {
            using (var db = new ChushkaDbContext())
            {
                db.Database.Migrate();

                // Uncommet the next line to seed the database!
                // SeedDatabase(db);
            }

            var server = new SoftUni.WebServer.Server.WebServer(1337, new ControllerRouter(), new ResourceRouter());
            MvcEngine.Run(server);
        }

        private static void SeedDatabase(ChushkaDbContext db)
        {
            var roles = new List<Role>()
            {
                new Role() { Name = "User" },
                new Role() { Name = "Admin" }
            };

            var productTypes = new List<ProductType>()
            {
                new ProductType() { Name = "Food" },
                new ProductType() { Name = "Domestic" },
                new ProductType() { Name = "Health" },
                new ProductType() { Name = "Cosmetic" },
                new ProductType() { Name = "Other" },
            };

            db.Roles.AddRange(roles);
            db.ProductTypes.AddRange(productTypes);
            db.SaveChanges();

            Console.WriteLine("Database Seeded!"); 
        }
    }
}
