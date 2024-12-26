using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using P04_Model_Validation.CustomValidators;

namespace P04_Model_Validation.Models;

public class Person
{
    [Required(ErrorMessage = "{0} can't be empty or null")]
    [Display(Name = "Person Name")]
    [StringLength(5, MinimumLength = 2, ErrorMessage = "{0} should be between {2} and {1} characters long")]
    [RegularExpression("^[A-Za-z .]+$", ErrorMessage = "{0} formation invalid!")]
    public string? PersonName { get; set; }

    [EmailAddress(ErrorMessage = "invalid {0} address")]
    [Required]
    public string? Email { get; set; }

    // [Phone(ErrorMessage = "invalid {0} number")]
    [ValidateNever] public string? Phone { get; set; }

    [Required(ErrorMessage = "{0} can't be blank")]
    public string? Password { get; set; }

    [Required(ErrorMessage = "{0} can't be blank")]
    [Compare("Password", ErrorMessage = "{0} and {1} doesn't match")]
    [Display(Name = "Re-enter Password")]
    public string? ConfirmPassword { get; set; }

    [Range(0, 99.99, ErrorMessage = "{0} should be between ${1} and ${2}")]
    public double? Price { get; set; }

    [MinimumYearValidator(1995)]
    public DateTime? DateOfBirth { get; set; }

    public override string ToString()
    {
        return
            $"{nameof(PersonName)}: {PersonName}, {nameof(Email)}: {Email}, " +
            $"{nameof(Phone)}: {Phone}, {nameof(Password)}: {Password}, " +
            $"{nameof(ConfirmPassword)}: {ConfirmPassword}, {nameof(Price)}: {Price}";
    }
}