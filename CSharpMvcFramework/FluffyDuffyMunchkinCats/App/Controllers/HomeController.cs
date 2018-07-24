using App.Models;
using Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace App.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext dbContext;

        public HomeController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.dbContext.Database.EnsureCreated();
        }

        public IActionResult Index()
        {
            CatListViewModel[] cats;

            using (this.dbContext)
            {
                cats = this.dbContext.Cats
                    .Select(c => new CatListViewModel()
                    {
                        Id = c.Id,
                        Name = c.Name
                    })
                    .ToArray();
            }

            return View(cats);
        }
    }
}