using SoftUni.WebServer.Mvc.Controllers;
using SoftUni.WebServer.Mvc.Interfaces;
using System.IO;

namespace SoftUni.App.Chushka.Controllers
{
    public class BaseController : Controller
    {
        protected const string TemplateDir = "../../../Templates";

        private const string AdminNavBarTemplate = "/Common/AdminNav.html";
        private const string UserNavBarTemplate = "/Common/UserNav.html";
        private const string GuestNavBarTemplate = "/Common/GuestNav.html";

        protected bool IsAdmin => this.User.IsInRole("Admin");

        public override void OnControllerCreated()
        {
            this.ViewData["showError"] = "none";
            this.ViewData["errorMessage"] = string.Empty;
        }

        public override void OnAuthentication()
        {
            if (this.User.IsAuthenticated)
            {
                if (this.IsAdmin)
                {
                    this.ViewData["navbar"] = File.ReadAllText(TemplateDir + AdminNavBarTemplate);
                }
                else
                {
                    this.ViewData["navbar"] = File.ReadAllText(TemplateDir + UserNavBarTemplate);
                }
            }
            else
            {
                this.ViewData["navbar"] = File.ReadAllText(TemplateDir + GuestNavBarTemplate);
            }
        }

        protected IRedirectable RedirectToHomePage() => this.RedirectToAction("/home/index");

        protected void ShowError(string message)
        {
            this.ViewData["showError"] = "block";
            this.ViewData["errorMessage"] = message;
        }
    }
}
