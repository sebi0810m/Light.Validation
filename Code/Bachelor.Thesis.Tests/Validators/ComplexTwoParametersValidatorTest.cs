﻿using System.ComponentModel.DataAnnotations;
using Bachelor.Thesis.Benchmarking.ComplexTwoParameters.Dto;
using Bachelor.Thesis.Benchmarking.ComplexTwoParameters.FluentValidator;
using Bachelor.Thesis.Benchmarking.ComplexTwoParameters.LightValidator;
using Light.GuardClauses;
using Xunit;

namespace Bachelor.Thesis.Tests.Validators;

public class ComplexTwoParametersValidatorTest
{
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
        var result = Validator.TryValidateObject(_validCustomer, new ValidationContext(_validCustomer), null, true);

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
        var result = Validator.TryValidateObject(_invalidCustomer, new ValidationContext(_invalidCustomer), null, true);

        result.MustBe(false);
    }
}