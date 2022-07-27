using Light.Validation;
using Light.Validation.Checks;
using Range = Light.Validation.Tools.Range;

namespace Bachelor.Thesis.Benchmarking.ParametersPrimitiveTwo.Validators;

public class LightValidator : Validator<UserDto>
{
    public LightValidator() : base(Light.Validation.ValidationContextFactory.Instance) { }

    protected override UserDto PerformValidation(ValidationContext context, UserDto value)
    {
        value.Id = context.Check(value.Id).IsGreaterThan(0);

        value.Name = context.Check(value.Name)
                            .IsNotNullOrWhiteSpace()
                            .HasLengthIn(Range.FromInclusive(2).ToInclusive(80));

        return value;
    }
}