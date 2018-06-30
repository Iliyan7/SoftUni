using Framework.Controllers;

namespace MeTube.Controllers
{
    public class BaseController : Controller
    {
        protected const string LoggedOutHomePage = "/home/index";
        protected const string LoggedInHomePage = "/users/home";

        public BaseController()
        {
            this.ViewData["display"] = "none";
            this.ViewData["error"] = string.Empty;
        }

        protected void ShowErrorInfo(string message)
        {
            this.ViewData["display"] = "block";
            this.ViewData["error"] = message;
        }

        protected override void OnAuthentication()
        {
            this.ViewData["navbar"] = this.User.IsAuthenticated ?
                @"<li class=""nav-item active col-md-3"">
                    <a class=""nav-link h5"" href=""/users/home"">Home</a>
                </li>
                <li class=""nav-item active col-md-3"">
                    <a class=""nav-link h5"" href=""/users/profile"">Profile</a>
                </li>
                <li class=""nav-item active col-md-3"">
                    <a class=""nav-link h5"" href=""/tubes/upload"">Upload</a>
                </li>
                <li class=""nav-item active col-md-3"">
                    <a class=""nav-link h5"" href=""/users/logout"">Logout</a>
                </li>"
                 :
                @"<li class=""nav-item active col-md-4"">
                    <a class=""nav-link h5"" href=""/home/index"">Home</a>
                </li>
                <li class=""nav-item active col-md-4"">
                    <a class=""nav-link h5"" href=""/users/login"">Login</a>
                </li>
                <li class=""nav-item active col-md-4"">
                    <a class=""nav-link h5"" href=""/users/register"">Register</a>
                </li>";
        }
    }
}
