using System;
using System.ComponentModel.DataAnnotations;

namespace App.Attributes
{
    public class DateGreatherThanAttribute : ValidationAttribute
    {
        private readonly string otherProperty;

        public DateGreatherThanAttribute(string otherProperty)
        {
            this.otherProperty = otherProperty;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var property = validationContext
                .ObjectType
                .GetProperty(this.otherProperty);

            if (property == null)
            {
                throw new ArgumentException($"The property {this.otherProperty} could not be found.");
            }

            var otherDate = (DateTime)property.GetValue(validationContext.ObjectInstance);

            if (value != null)
            {
                var result = DateTime.Compare((DateTime)value, otherDate);

                if (result <= 0)
                {
                    return new ValidationResult(this.ErrorMessage);
                }
            }

            return ValidationResult.Success;
        }
    }
}
