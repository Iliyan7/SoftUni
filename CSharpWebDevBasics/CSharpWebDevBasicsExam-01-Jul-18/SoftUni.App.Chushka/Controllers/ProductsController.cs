using Microsoft.EntityFrameworkCore;
using SoftUni.App.Chushka.BindingModels;
using SoftUni.App.Chushka.ViewModels;
using SoftUni.App.Data;
using SoftUni.App.Models;
using SoftUni.WebServer.Mvc.Attributes.HttpMethods;
using SoftUni.WebServer.Mvc.Interfaces;
using System;
using System.IO;
using System.Linq;

namespace SoftUni.App.Chushka.Controllers
{
    public class ProductsController : BaseController
    {
        private const string AdminDetailsActionsTemplate = "/Products/AdminDetailsActions.html";
        private const string UserDetailsActionsTemplate = "/Products/UserDetailsActions.html";

        [HttpGet]
        public IActionResult Details(int id)
        {
            if (!this.User.IsAuthenticated)
            {
                return this.RedirectToHomePage();
            }

            ProductDetailsViewModel productDetails;

            using (var db = new ChushkaDbContext())
            {
                productDetails = db.Products
                    .Where(p => p.Id == id)
                    .Select(p => new ProductDetailsViewModel()
                    {
                        Name = p.Name,
                        Type = p.Type.Name,
                        Price = p.Price,
                        Description = p.Description
                    })
                    .FirstOrDefault();

                if (productDetails == null)
                {
                    return this.RedirectToHomePage();
                }
            }

            this.ViewData["name"] = productDetails.Name;
            this.ViewData["type"] = productDetails.Type;
            this.ViewData["price"] = productDetails.Price.ToString("0.##");
            this.ViewData["description"] = productDetails.Description;
            this.ViewData["actions"] = this.IsAdmin ? File.ReadAllText(TemplateDir + AdminDetailsActionsTemplate) : File.ReadAllText(TemplateDir + UserDetailsActionsTemplate);
            this.ViewData["productId"] = id.ToString();

            return this.View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            if (!this.IsAdmin)
            {
                return this.RedirectToHomePage();
            }

            return this.View();
        }

        [HttpPost]
        public IActionResult Create(CreateProductModel model)
        {
            if (!this.IsAdmin)
            {
                return this.RedirectToHomePage();
            }

            if (!this.IsValidModel(model))
            {
                this.ShowError(this.GetValidationSummary());
                return this.View();
            }

            ProductType productType;
            Product product;

            using (var db = new ChushkaDbContext())
            {
                productType = db
                    .ProductTypes
                    .FirstOrDefault(pt => pt.Name == model.ProductType);

                if (productType == null)
                {
                    productType = new ProductType() { Name = model.ProductType };
                    db.ProductTypes.Add(productType);
                }

                product = new Product()
                {
                    Name = model.Name,
                    Price = model.Price,
                    Description = model.Description,
                    Type = productType
                };

                db.Products.Add(product);
                db.SaveChanges();
            }

            return this.RedirectToHomePage();
        }

        [HttpGet]
        public IActionResult Order(int id)
        {
            if (!this.User.IsAuthenticated)
            {
                return this.RedirectToHomePage();
            }

            using (var db = new ChushkaDbContext())
            {
                db.Orders.Add(new Order()
                {
                    ClientId = this.User.Id,
                    ProductId = id,
                    OrderedOn = DateTime.Now
                });

                db.SaveChanges();
            }

            return this.IsAdmin ? this.RedirectToAction("/orders/all") : this.RedirectToHomePage();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (!IsAdmin)
            {
                return this.RedirectToHomePage();
            }

            Product product;
            ProductType[] productTypes;

            using (var db = new ChushkaDbContext())
            {
                product = db.Products
                    .Include(p => p.Type)
                    .FirstOrDefault(p => p.Id == id);

                if (product == null)
                {
                    return this.RedirectToHomePage();
                }

                productTypes = db.ProductTypes.ToArray();
            }

            this.ViewData["productId"] = product.Id.ToString();
            this.ViewData["name"] = product.Name;
            this.ViewData["price"] = product.Price.ToString("0.##");
            this.ViewData["description"] = product.Description;

            for (int i = 0; i < productTypes.Length; i++)
            {
                if (product.Type.Name == productTypes[i].Name)
                {
                    this.ViewData[$"isChecked{i + 1}"] = "checked";
                }
                else
                {
                    this.ViewData[$"isChecked{i + 1}"] = string.Empty;
                }
            }

            return this.View();
        }

        [HttpPost]
        public IActionResult Edit(EditProductModel model)
        {
            if (!IsAdmin)
            {
                return this.RedirectToHomePage();
            }

            if (!this.IsValidModel(model))
            {
                this.ShowError(this.GetValidationSummary());
                this.ViewData["productId"] = model.Id.ToString();
                this.ViewData["name"] = model.Name;
                this.ViewData["price"] = model.Price.ToString("0.##");
                this.ViewData["description"] = model.Description;
                return this.View();
            }

            using (var db = new ChushkaDbContext())
            {
                var productType = db
                    .ProductTypes
                    .FirstOrDefault(pt => pt.Name == model.ProductType);

                if (productType == null)
                {
                    productType = new ProductType() { Name = model.ProductType };
                    db.ProductTypes.Add(productType);
                }

                var product = db.Products.FirstOrDefault(p => p.Id == model.Id);
                product.Name = model.Name;
                product.Price = model.Price;
                product.Description = model.Description;
                product.Type = productType;

                db.SaveChanges();
            }

            return this.RedirectToHomePage();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (!IsAdmin)
            {
                return this.RedirectToHomePage();
            }

            Product product;
            using (var db = new ChushkaDbContext())
            {
                product = db.Products.Find(id);

                if (product == null)
                {
                    return this.RedirectToHomePage();
                }

                db.Products.Remove(product);
                db.SaveChanges();
            }

            return this.RedirectToHomePage();
        }
    }
}
