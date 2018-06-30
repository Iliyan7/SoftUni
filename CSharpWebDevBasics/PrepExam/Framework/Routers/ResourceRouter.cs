using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using WebServer.Contracts;
using WebServer.Enums;
using WebServer.Http.Contracts;
using WebServer.Http.Response;

namespace Framework.Routers
{
    public class ResourceRouter : IHandleable
    {
        private static readonly IDictionary<string, string> ExtensionsToMIMETypes = new Dictionary<string, string>()
        {
            ["html"] = "text/html",
            ["css"] = "text/css",
            ["gif"] = "image/gif",
            ["png"] = "image/png",
            ["jpeg"] = "image/jpeg",
            ["bmp"] = "image/bmp",
            ["ico"] = "image/x-icon",
            ["js"] = "application/javascript",
        };

        public IHttpResponse Handle(IHttpRequest request)
        {
            try
            {
                var filePath = request.Path;
                string extension = filePath
                    .Split('.')
                    .Last();

                if (!ExtensionsToMIMETypes.ContainsKey(extension))
                {
                    throw new InvalidOperationException("The file type is not supported.");
                }

                byte[] fileContent = this.ReadFileContent(filePath);

                return new FileResponse(HttpStatusCode.OK, fileContent, ExtensionsToMIMETypes[extension]);
            }
            catch (Exception)
            {
                return new NotFoundResponse();
            }
        }

        private byte[] ReadFileContent(string filePath)
        {
            var fullFilePath = string.Format(@"..\..\..\{0}\{1}",
                MvcContext.Instance.ResourceFolder,
                filePath);

            var byteContent = File.ReadAllBytes(fullFilePath);
            return byteContent;
        }
    }
}
