using Framework.Interfaces;
using Framework.Interfaces.Generic;
using Framework.ViewEngine;
using Framework.ViewEngine.Generic;
using System.Runtime.CompilerServices;

namespace Framework.Controllers
{
    public class Controller
    {
        protected IActionResult View([CallerMemberName]string action = "")
        {
            var controller = this.GetType().Name.Replace(MvcContext.Instance.ControllersSuffix, string.Empty);

            var fullQualifiedName = string.Format("{0}.{1}.{2}.{3}, {0}",
                MvcContext.Instance.AssemblyName,
                MvcContext.Instance.ViewsFolder,
                controller,
                action);

            return new ActionResult(fullQualifiedName);
        }

        protected IActionResult View(string controller, string action)
        {
            var fullQualifiedName = string.Format("{0}.{1}.{2}.{3}, {0}",
                MvcContext.Instance.AssemblyName,
                MvcContext.Instance.ViewsFolder,
                controller,
                action);

            return new ActionResult(fullQualifiedName);
        }

        protected IActionResult<T> View<T>(T model, [CallerMemberName]string action = "")
        {
            var controller = this.GetType().Name.Replace(MvcContext.Instance.ControllersSuffix, string.Empty);

            var fullQualifiedName = string.Format("{0}.{1}.{2}.{3}, {0}",
                MvcContext.Instance.AssemblyName,
                MvcContext.Instance.ViewsFolder,
                controller,
                action);

            return new ActionResult<T>(fullQualifiedName, model);
        }

        protected IActionResult<T> View<T>(T model, string controller, string action)
        {
            var fullQualifiedName = string.Format("{0}.{1}.{2}.{3}, {0}",
                MvcContext.Instance.AssemblyName,
                MvcContext.Instance.ViewsFolder,
                controller,
                action);

            return new ActionResult<T>(fullQualifiedName, model);
        }


    }
}
