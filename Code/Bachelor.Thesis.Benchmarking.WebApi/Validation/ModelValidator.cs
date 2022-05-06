using System.ComponentModel.DataAnnotations;

namespace Bachelor.Thesis.Benchmarking.WebApi.Validation;

public class ModelValidator<T>
{
    private readonly T _itemToValidate;

    public ModelValidator(T itemToValidate)
    {
        _itemToValidate = itemToValidate;
    }

    public List<ValidationResult> PerformValidation()
    {
        var errors = new List<ValidationResult>();
        Validator.TryValidateObject(_itemToValidate!, new ValidationContext(_itemToValidate!), errors, true);
        return errors;
    }
}