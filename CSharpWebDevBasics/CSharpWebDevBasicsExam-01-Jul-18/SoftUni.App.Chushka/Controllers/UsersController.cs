using SoftUni.App.Chushka.BindingModels;
using SoftUni.App.Chushka.ViewModels;
using SoftUni.App.Data;
using SoftUni.App.Models;
using SoftUni.WebServer.Common;
using SoftUni.WebServer.Mvc.Attributes.HttpMethods;
using SoftUni.WebServer.Mvc.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace SoftUni.App.Chushka.Controllers
{
    public class UsersController : BaseController
    {
        private const string DefaultRole = "User";

        [HttpGet]
        public IActionResult Login()
        {
            if (this.User.IsAuthenticated)
            {
                return this.RedirectToHomePage();
            }

            return this.View();
        }

        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            if (this.User.IsAuthenticated)
            {
                return this.RedirectToHomePage();
            }

            if (!this.IsValidModel(model))
            {
                this.ShowError(this.GetValidationSummary());
                return this.View();
            }

            UserLoginViewModel user;
            using (var db = new ChushkaDbContext())
            {
                user = db.Users
                    .Select(u => new UserLoginViewModel()
                    {
                        Id = u.Id,
                        Username = u.Username,
                        PasswordHash = u.PasswordHash,
                        RoleName = u.Role.Name
                    })
                    .FirstOrDefault(u => u.Username == model.Username);
            }

            if (user == null || user.PasswordHash != PasswordUtilities.GetPasswordHash(model.Password))
            {
                this.ShowError("Your login details are incorrect!");
                return this.View();
            }

            var roles = new List<string>()
            {
                user.RoleName
            };

            this.SignIn(user.Username, user.Id, roles);
            return this.RedirectToHomePage();
        }

        [HttpGet]
        public IActionResult Register()
        {
            if (this.User.IsAuthenticated)
            {
                return this.RedirectToHomePage();
            }

            return this.View();
        }

        [HttpPost]
        public IActionResult Register(RegisterModel model)
        {
            if (this.User.IsAuthenticated)
            {
                return this.RedirectToHomePage();
            }

            if (!this.IsValidModel(model))
            {
                this.ShowError(this.GetValidationSummary());
                return this.View();
            }

            Role role;
            User user;

            using (var db = new ChushkaDbContext())
            {
                role = db.Roles
                    .Where(r => r.Name == DefaultRole)
                    .FirstOrDefault();

                if (role == null)
                {
                    role = new Role() { Name = DefaultRole };
                    db.Roles.Add(role);
                }

                user = new User()
                {
                    Username = model.Username,
                    PasswordHash = PasswordUtilities.GetPasswordHash(model.Password),
                    FullName = model.FullName,
                    Email = model.Email,
                    Role = role
                };

                db.Users.Add(user);
                db.SaveChanges();
            }

            var roles = new List<string>()
            {
                role.Name
            };

            this.SignIn(user.Username, user.Id, roles);
            return this.RedirectToHomePage();
        }

        [HttpGet]
        public IActionResult Logout()
        {
            if (!this.User.IsAuthenticated)
            {
                return this.RedirectToHomePage();
            }

            this.SignOut();
            return this.RedirectToHomePage();
        }
    }
}
