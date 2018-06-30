using System;

namespace Framework.Attributes.Validation
{
    public abstract class PropertyAttribute : Attribute
    {
        public abstract bool IsValid(object value);
    }
}
