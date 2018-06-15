using Framework.Attributes.Methods;
using Framework.Controllers;
using Framework.Interfaces;
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
        private IDictionary<string, string> getParams;
        private IDictionary<string, string> postParams;
        private string requestMethod;
        private string controllerName;
        private string actionName;
        private object[] methodParams;

        public IHttpResponse Handle(IHttpRequest request)
        {
            this.getParams = request.UrlParameters;
            this.postParams = request.FormData;
            this.requestMethod = request.Method.ToString();

            var pathParts = request.Path
                .Split('/');

            if(pathParts.Length != 2)
            {
                throw new ArgumentException("Invalid URL");
            }

            this.controllerName = $"{CapitalizeFirstLetter(pathParts[0])}Controller";
            this.actionName = CapitalizeFirstLetter(pathParts[1]);

            var method = this.GetMethod();

            if(method == null)
            {
                return new NotFoundResponse();
            }

            var parameters = method.GetParameters();

            this.methodParams = new object[parameters.Count()];

            int index = 0;
            foreach (var param in parameters)
            {
                if(param.ParameterType.IsPrimitive || param.ParameterType == typeof(string))
                {
                    object value = this.getParams[param.Name];
                    this.methodParams[index++] = Convert.ChangeType(value, param.ParameterType);
                }
                else
                {
                    var bindingModelType = param.ParameterType;
                    object bindingModel = Activator.CreateInstance(bindingModelType);

                    var properties = bindingModelType.GetProperties();

                    foreach (var property in properties)
                    {
                        property.SetValue(bindingModel, Convert.ChangeType(this.postParams[property.Name], property.PropertyType));
                    }

                    this.methodParams[index++] = Convert.ChangeType(bindingModel, bindingModelType);
                }
            }

            var actionResult = (IInvocable)this.GetMethod()
                .Invoke(this.GetController(), this.methodParams);

            var content = actionResult.Invoke();

            var response = new ContentResponse(HttpStatusCode.OK, content);

            return response;
            
        }

        private string CapitalizeFirstLetter(string str)
        {
            return string.Format("{0}{1}", char.ToUpper(str[0]), str.Substring(1));
        }

        private MethodInfo GetMethod()
        {
            MethodInfo method = null;

            foreach (var methodInfo in this.GetSuitableMethods())
            {
                var attributes = methodInfo
                    .GetCustomAttributes()
                    .Where(a => a is HttpMethodAttribute);

                if(!attributes.Any() && this.requestMethod == "GET")
                {
                    return methodInfo;
                }

                foreach (HttpMethodAttribute attribute in attributes)
                {
                    if (attribute.IsValid(this.requestMethod))
                    {
                        return methodInfo;
                    }
                }
            }

            return method;
        }

        private IEnumerable<MethodInfo> GetSuitableMethods()
        {
            var controller = this.GetController();

            if(controller == null)
            {
                return new MethodInfo[0];
            }

            return this.GetController()
                .GetType()
                .GetMethods()
                .Where(m => m.Name == this.actionName);
        }

        private Controller GetController()
        {
            var controllerFullQualified = string.Format("{0}.{1}.{2}, {0}",
                MvcContext.Instance.AssemblyName,
                MvcContext.Instance.ControllersFolder,
                this.controllerName);

            var type = Type.GetType(controllerFullQualified);

            if(type == null)
            {
                return null;
            }

            var controller = (Controller)Activator.CreateInstance(type);

            return controller;
        }
    }
}
