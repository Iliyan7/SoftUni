using Framework.ActionResults;
using Framework.Attributes.Validation;
using Framework.Contracts;
using Framework.Models;
using Framework.Security;
using Framework.Views;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using WebServer.Http.Contracts;

namespace Framework.Controllers
{
    public abstract class Controller
    {
        protected Controller()
        {
            this.Model = new ViewModel();
            this.User = new Authentication();
        }

        protected internal IHttpRequest Request { get; set; }

        protected ViewModel Model { get; }

        protected Authentication User { get; private set; }

        protected IViewable View([CallerMemberName]string action = "")
        {
            this.Model["displayType"] = this.User.IsAuthenticated ? "block" : "none";

            var controller = this.GetType()
                .Name
                .Replace(MvcContext.Instance.ControllersSuffix, string.Empty);

            var fullQualifiedName = string.Format("{0}\\{1}\\{2}",
                MvcContext.Instance.ViewsFolder,
                controller,
                action);

            IRenderable view = new View(fullQualifiedName, this.Model.Data);

            return new ViewResult(view);
        }

        protected IRedirectable RedirectToAction(string redirectUrl)
        {
            return new RedirectResult(redirectUrl);
        }

        protected bool IsValidModel(object bindingModel)
        {
            foreach (var property in bindingModel.GetType().GetProperties())
            {
                var attributes = property
                    .GetCustomAttributes()
                    .Where(a => a is PropertyAttribute)
                    .Cast<PropertyAttribute>();

                if(!attributes.Any())
                {
                    continue;
                }

                foreach (PropertyAttribute attribute in attributes)
                {
                    if(!attribute.IsValid(property.GetValue(bindingModel)))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        protected internal void InitializeUser()
        {
            var user = this.Request
                .Session
                .Get<string>("username");

            if (user != null)
            {
                this.User = new Authentication(user);
            }
        }

        protected void SignIn(string name)
        {
            this.Request.Session.Add("username", name);
        }

        protected void SignOut()
        {
            this.Request.Session.Clear();
        }
    }
}
