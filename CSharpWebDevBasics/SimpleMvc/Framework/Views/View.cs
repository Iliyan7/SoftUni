using Framework.Contracts;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Framework.Views
{
    public class View : IRenderable
    {
        public const string BASE_LAYOUT_FILENAME = "Layout";

        public const string CONTENT_PLACEHOLDER = "{{{content}}}";

        public const string HTML_EXTENSION = ".html";

        public const string LOCAL_ERROR_PATH = "..\\..\\..\\..\\Framework\\Errors\\Error.html";

        public readonly string templateFullQualifiedName;

        private readonly IDictionary<string, string> viewData;

        public View(string templateFullQualifiedName, IDictionary<string, string> viewData)
        {
            this.templateFullQualifiedName = templateFullQualifiedName;
            this.viewData = viewData;
        }

        public string Render()
        {
            var fullHtml = this.ReadFile();

            if(this.viewData.Any())
            {
                foreach (var param in this.viewData)
                {
                    fullHtml = fullHtml.Replace($"{{{{{{{param.Key}}}}}}}", param.Value);
                }
            }

            return fullHtml;
        }

        private string ReadFile()
        {
            var layoutHtml = this.RenderLayoutHtml();

            var templateFullQualifiedNameWithExtension = string.Format("..\\..\\..\\{0}{1}",
                this.templateFullQualifiedName,
                HTML_EXTENSION);

            if (!File.Exists(templateFullQualifiedNameWithExtension))
            {
                this.viewData.Add("error", "Requested view does not exist!");
                return File.ReadAllText(LOCAL_ERROR_PATH);
            }

            var templateHtml = File.ReadAllText(templateFullQualifiedNameWithExtension);
            return layoutHtml.Replace(CONTENT_PLACEHOLDER, templateHtml);
        }

        private string RenderLayoutHtml()
        {
            var layoutHtmlQualifiedName = string.Format("..\\..\\..\\{0}\\{1}{2}",
                MvcContext.Instance.ViewsFolder,
                BASE_LAYOUT_FILENAME,
                HTML_EXTENSION);

            if(!File.Exists(layoutHtmlQualifiedName))
            {
                this.viewData.Add("error", "Requested view does not exist!");
                return File.ReadAllText(LOCAL_ERROR_PATH);
            }

            return File.ReadAllText(layoutHtmlQualifiedName);
        }
    }
}
