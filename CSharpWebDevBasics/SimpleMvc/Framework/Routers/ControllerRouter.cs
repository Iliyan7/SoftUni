using Framework.Attributes.Methods;
using Framework.Controllers;
using Framework.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using WebServer.Contracts;
using WebServer.Enums;
using WebServer.Http.Contracts;
using WebServer.Http.Response;

namespace Framework.Routers
{
    public class ControllerRouter : IHandleable
    {
        private const string DEFAULT_PATH = "/";
        private const string DEFAULT_CONTROLLER = "HomeController";
        private const string DEFAULT_ACTION = "Index";

        public IHttpResponse Handle(IHttpRequest request)
        {
            IDictionary<string, string> getParams = request.UrlParameters;
            IDictionary<string, string> postParams = request.FormData;
            string requestMethod = request.Method.ToString();

            this.GetControllerAndActionName(request.Path, out string controllerName, out string actionName);

            var controller = this.GetController(controllerName, request);
            var action = this.GetAction(controller, requestMethod, actionName);

            if (action == null)
            {
                return new NotFoundResponse();
            }

            IEnumerable<ParameterInfo> parameters = action.GetParameters();

            var actionParams = this.AddParameters(parameters, getParams, postParams);

            try
            {
                var response = this.GetResponse(controller, action, actionParams);
                return response;
            }
            catch (Exception ex)
            {
                return new InternalServerErrorResponse(ex);
            }
        }

        private void GetControllerAndActionName(string path, out string controllerName, out string actionName)
        {
            if (path == DEFAULT_PATH)
            {
                controllerName = DEFAULT_CONTROLLER;
                actionName = DEFAULT_ACTION;
            }
            else
            {
                var controllerAndAction = path
                    .Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

                if (controllerAndAction.Length != 2)
                {
                    throw new ArgumentException("Invalid URL");
                }

                controllerName = CapitalizeFirstLetter(controllerAndAction[0]) + MvcContext.Instance.ControllersSuffix;
                actionName = CapitalizeFirstLetter(controllerAndAction[1]);
            }
        }

        private string CapitalizeFirstLetter(string str)
        {
            return string.Format("{0}{1}", char.ToUpper(str[0]), str.Substring(1));
        }

        private Controller GetController(string controllerName, IHttpRequest request)
        {
            var controllerFullQualifiedName = string.Format("{0}.{1}.{2}, {0}",
                MvcContext.Instance.AssemblyName,
                MvcContext.Instance.ControllersFolder,
                controllerName);

            var type = Type.GetType(controllerFullQualifiedName);

            if (type == null)
            {
                return null;
            }

            var controller = (Controller)Activator.CreateInstance(type);

           if (controller != null)
            {
                controller.Request = request;
                controller.InitializeUser();
            }

            return controller;
        }

        private MethodInfo GetAction(Controller controller, string requestMethod, string actionName)
        {
            MethodInfo method = null;

            foreach (var methodInfo in this.GetSuitableMethods(controller, actionName))
            {
                var attributes = methodInfo
                    .GetCustomAttributes()
                    .Where(a => a is HttpMethodAttribute);

                if(!attributes.Any() && requestMethod == "Get")
                {
                    return methodInfo;
                }

                foreach (HttpMethodAttribute attribute in attributes)
                {
                    if (attribute.IsValid(requestMethod))
                    {
                        return methodInfo;
                    }
                }
            }

            return method;
        }

        private IEnumerable<MethodInfo> GetSuitableMethods(Controller controller, string actionName)
        {
            if(controller == null)
            {
                return new MethodInfo[0];
            }

            return controller
                .GetType()
                .GetMethods()
                .Where(m => m.Name == actionName);
        }

        private object[] AddParameters(IEnumerable<ParameterInfo> parameters, IDictionary<string, string> getParams, IDictionary<string, string> postParams)
        {
            var actionParams = new object[parameters.Count()];

            var i = 0;
            foreach (var param in parameters)
            {
                if (param.ParameterType.IsPrimitive || param.ParameterType == typeof(string))
                {
                    actionParams[i] = this.ProcessPrimitiveParam(param, getParams);
                }
                else
                {
                    actionParams[i] = this.ProcessComplexParam(param, postParams);

                }
            }

            return actionParams;
        }

        private object ProcessPrimitiveParam(ParameterInfo param, IDictionary<string, string> getParams)
        {
            object value = getParams[param.Name];
            return Convert.ChangeType(value, param.ParameterType);
        }

        private object ProcessComplexParam(ParameterInfo param, IDictionary<string, string> postParams)
        {
            var bindingModelType = param.ParameterType;

            object bindingModel = Activator.CreateInstance(bindingModelType);

            IEnumerable<PropertyInfo> properties = bindingModelType.GetProperties();

            foreach (var property in properties)
            {
                property.SetValue(bindingModel, Convert.ChangeType(postParams[property.Name], property.PropertyType));
            }

            return Convert.ChangeType(bindingModel, bindingModelType);
        }

        private IHttpResponse GetResponse(Controller controller, MethodInfo action, object[] actionParams)
        {
            var actionResult = action.Invoke(controller, actionParams);

            IHttpResponse response = null;

            if (actionResult is IViewable)
            {
                var content = ((IViewable)actionResult).Invoke();

                response = new ContentResponse(HttpStatusCode.OK, content);
            }
            else if (actionResult is IRedirectable)
            {
                var redirectUrl = ((IRedirectable)actionResult).Invoke();

                response = new RedirectResponse(redirectUrl);
            }

            return response;
        }
    }
}
