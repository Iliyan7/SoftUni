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
        private readonly ICollection<ResourceType> resourceTypes = new List<ResourceType>()
        {
            new ResourceType("css", "text/css", "css"),
            new ResourceType("js", "text/javascript", "js"),
            new ResourceType("gif", "image/gif", "images"),
            new ResourceType("jpeg", "image/gif", "images"),
            new ResourceType("png", "image/png", "images"),
        };

        public IHttpResponse Handle(IHttpRequest request)
        {
            var fileFullName = request.Path
                .Split("/")
                .Last();

            var fileExtension = request.Path
                .Split(".")
                .Last();

            IHttpResponse fileResponse = null;

            try
            {
                var resourceType = resourceTypes.First(r => r.Extension == fileExtension);

                var fileContent = this.ReadFileContent(fileFullName, resourceType.Folder);

                fileResponse = new FileResponse(HttpStatusCode.Found, fileContent, resourceType.ContentType);
            }
            catch (Exception)
            {
                return new NotFoundResponse();
            }

            return fileResponse;
        }

        private byte[] ReadFileContent(string fileFullName, string folder)
        {
            var filePath = string.Format("..\\..\\..\\{0}\\{1}\\{2}",
                MvcContext.Instance.ResourceFolder,
                folder,
                fileFullName);

            var byteContent = File.ReadAllBytes(filePath);

            return byteContent;
        }
    }
}
