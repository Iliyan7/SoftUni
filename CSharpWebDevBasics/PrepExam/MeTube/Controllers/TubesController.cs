using System;
using System.Text.RegularExpressions;
using Data;
using Framework.Attributes.Methods;
using Framework.Contracts;
using MeTube.BindingModels;
using MeTube.ViewModels;
using Models;

namespace MeTube.Controllers
{
    public class TubesController : BaseController
    {
        [HttpGet]
        public IActionResult Upload()
        {
            if (!this.User.IsAuthenticated)
            {
                return this.RedirectToAction(LoggedOutHomePage);
            }

            return this.View();
        }

        [HttpPost]
        public IActionResult Upload(TubeUploadModel model)
        {
            if (!this.User.IsAuthenticated)
            {
                return this.RedirectToAction(LoggedOutHomePage);
            }

            if (!this.IsValidModel(model))
            {
                this.ShowErrorInfo("Your form is incorrect!");
                return this.View();
            }

            var youtubeId = GetYoutubeId(model.YoutubeLink);

            if (string.IsNullOrEmpty(youtubeId))
            {
                this.ShowErrorInfo("Invalid Youtube Link!");
                return this.View();
            }

            var tube = new Tube()
            {
                Title = model.Title,
                Author = model.Author,
                YoutubeId = youtubeId,
                Description = model.Description,
                UploaderId = this.User.Id
            };

            using (var db = new MeTubeDbContext())
            {
                db.Tubes.Add(tube);
                db.SaveChanges();
            }

            return this.RedirectToAction(LoggedInHomePage);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            if (!this.User.IsAuthenticated)
            {
                return this.RedirectToAction(LoggedOutHomePage);
            }

            TubeDetailsViewModel tubeDetails;

            using (var db = new MeTubeDbContext())
            {
                var tube = db.Tubes.Find(id);
                if(tube == null)
                {
                    return this.RedirectToAction(LoggedInHomePage);
                }

                tube.Views++;
                db.SaveChanges();

                tubeDetails = new TubeDetailsViewModel
                {
                    Title = tube.Title,
                    Author = tube.Author,
                    Description = tube.Description,
                    YoutubeId = tube.YoutubeId,
                    Views = tube.Views
                };
            }

            this.ViewData["title"] = tubeDetails.Title;
            this.ViewData["author"] = tubeDetails.Author;
            this.ViewData["description"] = tubeDetails.Description;
            this.ViewData["youtubeId"] = tubeDetails.YoutubeId;
            this.ViewData["views"] = $"{tubeDetails.Views} View{(tubeDetails.Views == 1 ? "" : "s")}";

            return this.View();
        }

        private string GetYoutubeId(string youtubeLink)
        {
            var pattern = @"(?>youtu\.be\/|youtube\.com\/)watch\?(?>.*&)?v=([^\?&""'>]+)";

            var match = Regex.Match(youtubeLink, pattern);

            if (match.Success)
            {
                return match.Groups[1].Value;
            }

            return null;
        }
    }
}
