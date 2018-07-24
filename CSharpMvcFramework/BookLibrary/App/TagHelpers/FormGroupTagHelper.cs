using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace App.TagHelpers
{
    [HtmlTargetElement("form-group")]
    public class FormGroupTagHelper : TagHelper
    {
        private const string _defaultLabelClass = "col-sm-2 col-form-label text-sm-right";
        private const string _defaultInputClass = "form-control";
        private const string _defaultValidationClass = "text-danger";

        private readonly IHtmlGenerator _htmlGenerator;

        public FormGroupTagHelper(IHtmlGenerator htmlGenerator)
        {
            _htmlGenerator = htmlGenerator;
        }

        [HtmlAttributeName("asp-for")]
        public ModelExpression For { get; set; }

        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.Attributes.SetAttribute("class", "form-group row");

            var label = await GenerateLabel(context);
            output.Content.AppendHtml(label);

            var textBox = await GenerateTextBox(context);
            var textBoxDiv = new TagBuilder("div");
            textBoxDiv.AddCssClass("col-sm-5");
            textBoxDiv.InnerHtml.AppendHtml(textBox);
            output.Content.AppendHtml(textBoxDiv);

            var validationMessage = await GenerateValidationMessage(context);
            var validationMessageDiv = new TagBuilder("div");
            validationMessageDiv.AddCssClass("col-sm-3");
            validationMessageDiv.InnerHtml.AppendHtml(validationMessage);
            output.Content.AppendHtml(validationMessageDiv);
        }

        private async Task<TagHelperOutput> GenerateLabel(TagHelperContext context)
        {
            var labelTagHelper =
                new LabelTagHelper(_htmlGenerator)
                {
                    For = this.For,
                    ViewContext = this.ViewContext,
                };

            var tagHelperOutput = CreateTagHelperOutput("label");
            tagHelperOutput.Attributes.Add(new TagHelperAttribute("class", _defaultLabelClass));

            await labelTagHelper.ProcessAsync(context, tagHelperOutput);

            return tagHelperOutput;
        }

        private async Task<TagHelperOutput> GenerateTextBox(TagHelperContext context)
        {
            var inputTagHelper =
               new InputTagHelper(_htmlGenerator)
               {
                   For = this.For,
                   ViewContext = this.ViewContext,
               };

            var tagHelperOutput = CreateTagHelperOutput("input");
            tagHelperOutput.Attributes.Add(new TagHelperAttribute("class", _defaultInputClass));
            tagHelperOutput.Attributes.Add(new TagHelperAttribute("placeholder", string.IsNullOrEmpty(this.For.Metadata.DisplayName) ? this.For.Metadata.Name : this.For.Metadata.DisplayName));

            await inputTagHelper.ProcessAsync(context, tagHelperOutput);

            return tagHelperOutput;
        }

        private async Task<TagHelperOutput> GenerateValidationMessage(TagHelperContext context)
        {
            var validationMessageTagHelper =
               new ValidationMessageTagHelper(_htmlGenerator)
               {
                   For = this.For,
                   ViewContext = this.ViewContext,
               };

            var inputOutput = CreateTagHelperOutput("span");
            inputOutput.Attributes.Add(new TagHelperAttribute("class", _defaultValidationClass));

            await validationMessageTagHelper.ProcessAsync(context, inputOutput);

            return inputOutput;
        }

        private TagHelperOutput CreateTagHelperOutput(string tagName)
        {
            return new TagHelperOutput(
                tagName: tagName,
                attributes: new TagHelperAttributeList(),
                getChildContentAsync: (s, t) =>
                {
                    return Task.Factory.StartNew<TagHelperContent>(
                            () => new DefaultTagHelperContent());
                }
            );
        }
    }
}
