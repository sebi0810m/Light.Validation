using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Bachelor.Thesis.Benchmarking.ParametersPrimitiveTwo;
using Bachelor.Thesis.Benchmarking.ParametersPrimitiveTwo.Validators;
using Light.GuardClauses;
using Xunit;
using Xunit.Abstractions;

namespace Bachelor.Thesis.Tests.Validators;

public class ParametersPrimitiveTwoValidatorTest
{
    private readonly UserDto _validUser = UserDto.ValidDto;
    private readonly UserDto _invalidUser = UserDto.InvalidDto;

    public ITestOutputHelper Output;

    public ParametersPrimitiveTwoValidatorTest(ITestOutputHelper output)
    {
        Output = output;
    }

    [Fact]
    public void FluentValidatorValidDtoTest()
    {
        var fluentValidator = new FluentValidator();
        var result = fluentValidator.Validate(_validUser);

        result.IsValid.MustBe(true);
    }

    [Fact]
    public void LightValidatorValidDtoTest()
    {
        var lightValidator = new LightValidator();
        var result = lightValidator.Validate(_validUser);

        result.IsValid.MustBe(true);
    }

    [Fact]
    public void ModelValidatorValidDtoTest()
    {
        var errors = new List<ValidationResult>();
        var result = Validator.TryValidateObject(_validUser, new ValidationContext(_validUser), errors, true);

        Output.WriteLine(Json.Serialize(errors));

        result.MustBe(true);
    }

    [Fact]
    public void FluentValidatorInvalidDtoTest()
    {
        var fluentValidator = new FluentValidator();
        var result = fluentValidator.Validate(_invalidUser);

        Output.WriteLine(Json.Serialize(result));

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

        Output.WriteLine(Json.Serialize(errors));

        result.MustBe(false);
    }
}