using Application.BindingModels;
using Data;
using Framework.Attributes.Methods;
using Framework.Contracts;
using Framework.Controllers;
using Models;
using System.Collections.Generic;
using System.Linq;

namespace Application.Controllers
{
    public class UsersController : Controller
    {
        [HttpPost]
        public IActionResult Logout()
        {
            this.SignOut();

            return RedirectToAction("/home/index");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginUserBindingModel bindingModel)
        {
            if (!this.IsValidModel(bindingModel))
            {
                return View();
            }

            using (var db = new NotesDbContext())
            {
                var foundUser = db
                    .Users
                    .FirstOrDefault(u => u.Username == bindingModel.Username);

                if (foundUser == null)
                {
                    return RedirectToAction("home/login");
                }

                this.SignIn(foundUser.Username);
            }

            return RedirectToAction("/home/index");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterUserBindingModel bindingModel)
        {
            if (!this.IsValidModel(bindingModel))
            {
                return View();
            }

            var user = new User()
            {
                Username = bindingModel.Username,
                Password = bindingModel.Password
            };

            using (var db = new NotesDbContext())
            {
                db.Users.Add(user);
                db.SaveChanges();
            }

            this.SignIn(user.Username);
            return RedirectToAction("/home/index");
        }

        [HttpGet]
        public IActionResult All()
        {
            if (!this.User.IsAuthenticated)
            {
                return RedirectToAction("/users/login");
            }

            var users = new Dictionary<int, string>();

            using (var db = new NotesDbContext())
            {
                users = db
                    .Users
                    .ToDictionary(u => u.Id, u => u.Username);
            }

            this.Model["users"] = string.Empty;

            if (users.Any())
            {
                this.Model["users"] = string.Join(
                    string.Empty,
                    users.Select(u => $"<li><a href=\"/users/profile?id={u.Key}\">{u.Value}</a></li>"));
            }

            return View();
        }

        [HttpGet]
        public IActionResult Profile(int id)
        {
            if (!this.User.IsAuthenticated)
            {
                return RedirectToAction("/users/login");
            }

            //this.Model["error"] = string.Empty;
            this.Model["username"] = this.User.Name;
            this.Model["userid"] = id.ToString();

            using (var db = new NotesDbContext())
            {
                var notes = db
                    .Notes
                    .Where(n => n.UserId == id)
                    .ToList();

                this.Model["notes"] = string.Join(
                    string.Empty,
                    notes.Select(u => $"<li>{u.Title}: {u.Content}</li>"));
            }

            return View();
        }

        [HttpPost]
        public IActionResult Profile(AddNoteBindingModel bindingModel)
        {
            if (!this.IsValidModel(bindingModel))
            {
                this.Model["error"] = "Form is not valid!";
                return Profile(bindingModel.UserId);
            }

            var note = new Note()
            {
                Title = bindingModel.Title,
                Content = bindingModel.Content,
                UserId = bindingModel.UserId
            };

            using (var db = new NotesDbContext())
            {
                db.Notes.Add(note);
                db.SaveChanges();
            }

            return RedirectToAction($"/users/profile?id={bindingModel.UserId}");
        }
    }
}
