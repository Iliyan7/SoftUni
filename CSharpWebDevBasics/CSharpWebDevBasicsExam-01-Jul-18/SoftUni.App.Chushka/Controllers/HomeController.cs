using SoftUni.App.Data;
using SoftUni.App.Models;
using SoftUni.WebServer.Mvc.Attributes.HttpMethods;
using SoftUni.WebServer.Mvc.Interfaces;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SoftUni.App.Chushka.Controllers
{
    public class HomeController : BaseController
    {
        [HttpGet]
        public IActionResult Index()
        {
            if (!this.User.IsAuthenticated)
            {
                this.ViewData["main"] = File.ReadAllText(TemplateDir + "/Home/GuestHomePage.html");
            }
            else
            {
                IList<Product> products;
                using (var db = new ChushkaDbContext())
                {
                    products = db.Products
                        .ToList();
                }

                var productsResult = new StringBuilder();
                productsResult.AppendLine(@"<div class=""row d-flex justify-content-around mt-4"">");

                for (int i = 0; i < products.Count; i++)
                {
                    var product = products[i];

                    productsResult.AppendLine(
                        $@"<a href=""/products/details?id={product.Id}"" class=""col-md-2"">
                            <div class=""product p-1 chushka-bg-color rounded-top rounded-bottom"">
                                <h5 class=""text-center mt-3"">{product.Name}</h5>
                                <hr class=""hr -1 bg-white"" />
                                <p class=""text -white text-center"" >
                                    {GetProductDescription(product.Description)}
                                </p>
                                <hr class=""hr -1 bg-white""/>
                                <h6 class=""text-center text-white mb-3"">${product.Price.ToString("0.##")}</h6>
                            </div>
                        </a>");

                    if ((i + 1) % 5 == 0)
                    {
                        productsResult.AppendLine(@"</div>");
                        productsResult.AppendLine(@"<div class=""row d-flex justify-content-around mt-4"">");
                    }
                }

                productsResult.AppendLine(@"</div>");

                this.ViewData["main"] = File.ReadAllText(TemplateDir + "/Home/UserHomePage.html");
                this.ViewData["username"] = this.User.Name;
                this.ViewData["products"] = productsResult.ToString();
            }

            return this.View();
        }

        private string GetProductDescription(string description)
        {
            if (description.Length > 50)
            {
                return description.Substring(0, 50) + "...";
            }

            return description;
        }
    }
}
