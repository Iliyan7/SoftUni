using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.RegularExpressions;

namespace App.HtmlHelpers
{
    public static class MarkHelper
    {
        public static IHtmlContent Mark(this IHtmlHelper htmlHelper, string text, string mark)
        {
            var pattern = $"({mark})";
            var replacement = "<mark class=\"p-0\">$1</mark>";

            var result = Regex.Replace(text, pattern, replacement, RegexOptions.IgnoreCase | RegexOptions.Compiled);

            return new HtmlString(result);
        }
    }
}
