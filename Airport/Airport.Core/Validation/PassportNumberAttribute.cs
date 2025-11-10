using System.ComponentModel.DataAnnotations;

namespace Airport.Core.Validation;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
public sealed class PassportNumberAttribute : ValidationAttribute
{
    public PassportNumberAttribute()
        : base("The passport number must start with 'P' or 'L', followed by one letter and 7 digits.") { }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        return PassportValidator.IsValid(value as string)
            ? ValidationResult.Success
            : new ValidationResult(ErrorMessage);
    }
}