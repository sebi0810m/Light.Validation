using FluentValidation;
using FluentValidation.Results;

namespace Bachelor.Thesis.Benchmarking.WebApi.Validation;

public class FluentValidator<T>
{
    private readonly T _itemToValidate;
    private readonly IValidator<T> _validator;

    public FluentValidator(IValidator<T> validator, T itemToValidate)
    {
        _validator = validator;
        _itemToValidate = itemToValidate;
    }

    public ValidationResult PerformValidation() =>
        _validator.Validate(_itemToValidate);
}