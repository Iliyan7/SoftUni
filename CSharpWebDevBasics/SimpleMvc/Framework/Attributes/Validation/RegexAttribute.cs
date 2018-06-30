using System.Text.RegularExpressions;

namespace Framework.Attributes.Validation
{
    public class RegexAttribute : PropertyAttribute
    {
        private string pattern;

        public RegexAttribute(string pattern)
        {
            this.pattern = "^" + pattern + "$";
        }
        public override bool IsValid(object value)
        {
            var valueAsString = value as string;
            if (valueAsString == null)
            {
                return false;
            }


            return Regex.IsMatch(valueAsString, this.pattern);
        }
    }
}
