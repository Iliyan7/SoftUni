using Framework.ActionResults;
using Framework.Contracts;
using Framework.Models;
using Framework.Security;
using Framework.Views;
using System;
using System.ComponentModel.DataAnnotations;
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
            this.ViewData = new ViewModel();
        }

        protected internal IHttpRequest Request { get; set; }

        protected User User { get; private set; }

        protected ViewModel ViewData { get; private set;  }

        protected internal void InitializeController()
        {
            var session = this.Request.Session;

            try
            {
                var userId = (int)session.Get(User.UserIdKey);
                var username = (string)session.Get(User.UsernameKey);

                this.User = new User(userId, username);
            }
            catch (Exception)
            {
                this.User = new User();
            }
        }

        protected internal abstract void OnAuthentication();

        protected bool IsValidModel(object bindingModel)
        {
            var isValid = true;

            var properties = bindingModel
                .GetType()
                .GetProperties();

            foreach (var property in properties)
            {
                var propertyValue = property.GetValue(bindingModel);

                var validationAttributes = property
                    .GetCustomAttributes()
                    .Where(a => a is ValidationAttribute)
                    .Cast<ValidationAttribute>();

                foreach (var validationAttribute in validationAttributes)
                {
                    var validationResult = validationAttribute.GetValidationResult(propertyValue, new ValidationContext(bindingModel));
                    if (validationResult != ValidationResult.Success)
                    {
                        isValid = false;
                    }
                }
            }

            return isValid;
        }

        protected IRedirectable RedirectToAction(string redirectUrl)
        {
            return new RedirectResult(redirectUrl);
        }

        protected void SignIn(int id, string name)
        {
            this.Request.Session.Add(User.UserIdKey, id);
            this.Request.Session.Add(User.UsernameKey, name);
        }

        protected void SignOut()
        {
            this.Request.Session.Clear();
        }

        protected IViewable View([CallerMemberName]string action = "")
        {
            var controller = this.GetType()
                .Name
                .Replace(MvcContext.Instance.ControllersSuffix, string.Empty);

            var fullQualifiedName = string.Format("{0}\\{1}\\{2}",
                MvcContext.Instance.ViewsFolder,
                controller,
                action);

            IRenderable view = new View(fullQualifiedName, this.ViewData.Data);

            return new ViewResult(view);
        }
    }
}
