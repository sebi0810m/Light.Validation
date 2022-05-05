using Light.Validation;

namespace Bachelor.Thesis.Benchmarking.WebApi.Validation;

public class LightValidator<T>
{
    private readonly T _itemToValidate;
    private readonly Validator<T> _validator;

    public LightValidator(Validator<T> validator, T itemToValidate)
    {
        _validator = validator;
        _itemToValidate = itemToValidate;
    }

    public ValidationResult<T> PerformValidation() =>
        _validator.Validate(_itemToValidate);
}