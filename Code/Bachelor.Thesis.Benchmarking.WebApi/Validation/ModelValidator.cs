using System.ComponentModel.DataAnnotations;

namespace Bachelor.Thesis.Benchmarking.WebApi.Validation;

public static class ModelValidator
{
    public static List<ValidationResult> PerformValidation<T>(T value)
    {
        var errors = new List<ValidationResult>();
        Validator.TryValidateObject(value!, new ValidationContext(value!), errors, true);
        return errors;
    }
}