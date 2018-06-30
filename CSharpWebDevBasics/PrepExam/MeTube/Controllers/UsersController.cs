using Data;
using Framework.Attributes.Methods;
using Framework.Contracts;
using MeTube.BindingModels;
using MeTube.ViewModels;
using Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MeTube.Controllers
{
    public class UsersController : BaseController
    {
        [HttpGet]
        public IActionResult Login()
        {
            if (this.User.IsAuthenticated)
            {
                return this.RedirectToAction(LoggedInHomePage);
            }

            return this.View();
        }

        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            if (this.User.IsAuthenticated)
            {
                return this.RedirectToAction(LoggedInHomePage);
            }

            if (!this.IsValidModel(model))
            {
                this.ShowErrorInfo("Your form is incorrect!");
                return this.View();
            }

            User user;
            using (var db = new MeTubeDbContext())
            {
                user = db.Users
                    .FirstOrDefault(u => u.Username == model.Username);
            }

            if (user.Password != model.Password)
            {
                this.ShowErrorInfo("Your login details are incorrect!");
                return this.View();
            }

            this.SignIn(user.Id, user.Username);
            return this.RedirectToAction(LoggedInHomePage);
        }

        [HttpGet]
        public IActionResult Register()
        {
            if (this.User.IsAuthenticated)
            {
                return this.RedirectToAction(LoggedInHomePage);
            }

            return this.View();
        }

        [HttpPost]
        public IActionResult Register(RegisterModel model)
        {
            if (this.User.IsAuthenticated)
            {
                return this.RedirectToAction(LoggedInHomePage);
            }

            if (!this.IsValidModel(model))
            {
                this.ShowErrorInfo("Your form is incorrect!");
                return this.View();
            }

            var user = new User()
            {
                Username = model.Username,
                Email = model.Email,
                Password = model.Password,
            };

            using (var db = new MeTubeDbContext())
            {
                db.Users.Add(user);
                db.SaveChanges();
            }

            this.SignIn(user.Id, user.Username);
            return this.RedirectToAction(LoggedInHomePage);
        }

        public IActionResult Logout()
        {
            this.SignOut();

            return this.RedirectToAction(LoggedOutHomePage);
        }

        public IActionResult Home()
        {
            if (!this.User.IsAuthenticated)
            {
                return this.RedirectToAction(LoggedOutHomePage);
            }

            IList<IndexTubesViewModel> tubes;

            using (var db = new MeTubeDbContext())
            {
                tubes = db.Tubes
                    .Select(t => new IndexTubesViewModel
                    {
                        Title = t.Title,
                        Author = t.Author,
                        YoutubeId = t.YoutubeId
                    })
                    .ToList();
            }

            var tubesResult = new StringBuilder();

            foreach (var tube in tubes)
            {
                tubesResult.Append(
                    $@"<div class=""col-md-4"">
                        <img class=""img-fluid img-thumbnail"" src=""https://img.youtube.com/vi/{tube.YoutubeId}/hqdefault.jpg"" alt=""{tube.Title}"" />
                        <p class=""text-center"">
                            {tube.Title}<br />
                            {tube.Author}
                        </p>
                    </div>"
                );
            }

            this.ViewData["username"] = this.User.Name;
            this.ViewData["tubes"] = tubesResult.ToString();

            return this.View();
        }

        public IActionResult Profile()
        {
            if (!this.User.IsAuthenticated)
            {
                return this.RedirectToAction(LoggedOutHomePage);
            }

            User user;
            IList<ProfileTubesViewModel> tubes;

            using (var db = new MeTubeDbContext())
            {
                user = db.Users
                   .FirstOrDefault(u => u.Username == this.User.Name);

                tubes = db.Tubes
                    .Where(t => t.UploaderId == user.Id)
                    .Select(t => new ProfileTubesViewModel
                    {
                        Id = t.Id,
                        Title = t.Title,
                        Author = t.Author,
                    })
                    .ToList();
            }

            var tubesResult = new StringBuilder();
            for (int i = 0; i < tubes.Count; i++)
            {
                var tube = tubes[i];

                tubesResult.AppendLine(
                    $@"<tr>
                        <td>{i+1}</td>
                        <td>{tube.Title}</td>
                        <td>{tube.Author}</td>
                        <td><a href=""/tubes/details?id={tube.Id}"">Details</a></td>
                    </tr>"
                );
            }

            this.ViewData["username"] = user.Username;
            this.ViewData["email"] = user.Email;
            this.ViewData["tubes"] = tubesResult.ToString();

            return this.View();
        }
    }
}
