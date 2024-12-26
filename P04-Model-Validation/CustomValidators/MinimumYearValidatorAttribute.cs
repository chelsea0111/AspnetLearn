using System.ComponentModel.DataAnnotations;

namespace P04_Model_Validation.CustomValidators;

public class MinimumYearValidatorAttribute : ValidationAttribute
{
    public int MinimumYear { get; set; } = 2000;
    public string DefaultErrorMessage { get; set; } = "Invalid Year of birth!";

    public MinimumYearValidatorAttribute(int minimumYear)
    {
        MinimumYear = minimumYear;
    }

    public MinimumYearValidatorAttribute()
    {
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value != null)
        {
            DateTime date = Convert.ToDateTime(value);
            if (date.Year >= MinimumYear)
            {
                ValidationResult result =
                    new ValidationResult(string.Format(ErrorMessage ?? DefaultErrorMessage,
                        MinimumYear));
                return result;
            }

            return ValidationResult.Success;
        }

        return null;
    }
}