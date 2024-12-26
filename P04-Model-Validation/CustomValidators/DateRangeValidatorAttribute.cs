using System.ComponentModel.DataAnnotations;
using System.Reflection;
using Microsoft.AspNetCore.Http.HttpResults;

namespace P04_Model_Validation.CustomValidators;

public class DateRangeValidatorAttribute : ValidationAttribute
{
    public string OtherPropertyName { get; set; }

    public DateRangeValidatorAttribute(string otherPropertyName)
    {
        OtherPropertyName = otherPropertyName;
    }

    public DateRangeValidatorAttribute()
    {
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value != null)
        {
            // use reflection to get value of the object 
            DateTime toDate = Convert.ToDateTime(value);
            PropertyInfo? otherProperty = validationContext.ObjectType.GetProperty(OtherPropertyName);
            DateTime fromDate = Convert.ToDateTime(otherProperty.GetValue(validationContext.ObjectInstance));
            if (toDate < fromDate)
            {
                return new ValidationResult(ErrorMessage);
            }
        }
        else
        {
            return ValidationResult.Success;
        }

        return null;
    }
}