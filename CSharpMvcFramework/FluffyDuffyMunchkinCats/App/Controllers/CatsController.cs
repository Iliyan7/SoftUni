using App.Models;
using Data;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace App.Controllers
{
    public class CatsController : Controller
    {
        private readonly AppDbContext dbContext;

        public CatsController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(CreateCatModel model)
        {
            using (this.dbContext)
            {
                var cat = new Cat()
                {
                    Name = model.Name,
                    Age = model.Age,
                    Breed = model.Breed,
                    ImageUrl = model.ImageUrl
                };

                this.dbContext.Cats.Add(cat);
                this.dbContext.SaveChanges();
            }

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Details(int id)
        {
            CatDetailsViewModel model;

            using (this.dbContext)
            {
                var cat = this.dbContext.Cats.Find(id);

                model = new CatDetailsViewModel()
                {
                    Name = cat.Name,
                    Age = cat.Age,
                    Breed = cat.Breed,
                    ImageUrl = cat.ImageUrl
                };
            }

            return View(model);
        }
    }
}