using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Bachelor.Thesis.Benchmarking.ParametersComplexTwo.Dto;
using Bachelor.Thesis.Benchmarking.ParametersComplexTwo.FluentValidator;
using Bachelor.Thesis.Benchmarking.ParametersComplexTwo.LightValidator;
using Light.GuardClauses;
using Xunit;
using Xunit.Abstractions;

namespace Bachelor.Thesis.Tests.Validators;

public class ParametersComplexTwoValidatorTest
{
    public ITestOutputHelper Output { get; }

    public ParametersComplexTwoValidatorTest(ITestOutputHelper output)
    {
        Output = output;
    }

    private readonly CustomerDto _validCustomer = CustomerDto.ValidCustomerDto;
    private readonly CustomerDto _invalidCustomer = CustomerDto.InvalidCustomerDto;

    [Fact]
    public void FluentValidatorValidDtoTest()
    {
        var fluentValidator = new FluentDtoValidator();
        var result = fluentValidator.Validate(_validCustomer);

        result.IsValid.MustBe(true);
    }

    [Fact]
    public void LightValidatorValidDtoTest()
    {
        var lightValidator = new LightDtoValidator();
        var result = lightValidator.Validate(_validCustomer);

        result.IsValid.MustBe(true);
    }

    [Fact]
    public void ModelValidatorValidDtoTest()
    {
        var errors = new List<ValidationResult>();
        var result = Validator.TryValidateObject(_validCustomer, new ValidationContext(_validCustomer), errors);

        result.MustBe(true);
    }

    [Fact]
    public void FluentValidatorInvalidDtoTest()
    {
        var fluentValidator = new FluentDtoValidator();
        var result = fluentValidator.Validate(_invalidCustomer);

        result.IsValid.MustBe(false);
    }

    [Fact]
    public void LightValidatorInvalidDtoTest()
    {
        var lightValidator = new LightDtoValidator();
        var result = lightValidator.Validate(_invalidCustomer);

        result.IsValid.MustBe(false);
    }

    [Fact]
    public void ModelValidatorInvalidDtoTest()
    {
        var errors = new List<ValidationResult>();
        var result = Validator.TryValidateObject(_invalidCustomer, new ValidationContext(_invalidCustomer), errors);

        Output.WriteLine(Json.Serialize(errors));

        result.MustBe(false);
    }
}