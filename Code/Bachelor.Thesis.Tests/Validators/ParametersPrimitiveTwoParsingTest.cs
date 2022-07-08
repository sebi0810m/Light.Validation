using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Bachelor.Thesis.Benchmarking.ParametersPrimitiveTwo;
using Bachelor.Thesis.Benchmarking.ParametersPrimitiveTwo.Validators;
using Light.GuardClauses;
using Xunit;
using Xunit.Abstractions;

namespace Bachelor.Thesis.Tests.Validators;

public class ParametersPrimitiveTwoParsingTest
{
    private readonly UserDto _invalidUser = UserDto.InvalidDto;

    public ITestOutputHelper Output;

    public ParametersPrimitiveTwoParsingTest(ITestOutputHelper output)
    {
        Output = output;
    }

    [Fact]
    public void FluentValidatorInvalidDtoTest()
    {
        var fluentValidator = new FluentValidator();
        var result = fluentValidator.Validate(_invalidUser);

        Output.WriteLine(Json.Serialize(result.FluentWriteInLightValidationResult(_invalidUser))); // TODO: IsValid is true => should be false

        result.IsValid.MustBe(false);
    }

    [Fact]
    public void LightValidatorInvalidDtoTest()
    {
        var lightValidator = new LightValidator();
        var result = lightValidator.Validate(_invalidUser);

        Output.WriteLine(Json.Serialize(result));

        result.IsValid.MustBe(false);
    }

    [Fact]
    public void ModelValidatorInvalidDtoTest()
    {
        var errors = new List<ValidationResult>();
        var result = Validator.TryValidateObject(_invalidUser, new ValidationContext(_invalidUser), errors, true);

        Output.WriteLine(Json.Serialize(errors.ModelWriteInLightValidationResult(_invalidUser))); // TODO: IsValid is true => should be false

        result.MustBe(false);
    }
}