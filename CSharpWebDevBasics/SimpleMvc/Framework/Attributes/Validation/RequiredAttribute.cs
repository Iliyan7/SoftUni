namespace Framework.Attributes.Validation
{
    public class RequiredAttribute : PropertyAttribute
    {
        public override bool IsValid(object value)
        {
            var valueAsString = value as string;

            return !string.IsNullOrEmpty(valueAsString);
        }
    }
}
