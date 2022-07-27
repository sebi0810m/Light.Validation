﻿using System.ComponentModel.DataAnnotations;
using Bachelor.Thesis.Benchmarking.ParametersComplexTwo.Dto;
using Bachelor.Thesis.Benchmarking.ParametersComplexTwo.FluentValidator;
using Bachelor.Thesis.Benchmarking.ParametersComplexTwo.LightValidator;
using BenchmarkDotNet.Attributes;

namespace Bachelor.Thesis.Benchmarking.ParametersComplexTwo;

[RPlotExporter]
public class InvalidCustomerDtoBenchmarks
{
    public CustomerDto Dto = CustomerDto.InvalidCustomerDto;

    public FluentDtoValidator FluentValidator = new ();
    public LightDtoValidator LightValidator = new ();

    [Benchmark(Baseline = true)]
    public object? CheckViaLightValidator()
    {
        LightValidator.CheckForErrors(Dto, out var errors);
        return errors;
    }

    [Benchmark]
    public object? CheckViaFluentValidator() =>
        FluentValidator.Validate(Dto);

    [Benchmark]
    public object CheckViaModelValidation()
    {
        var errors = new List<ValidationResult>();
        Validator.TryValidateObject(Dto, new ValidationContext(Dto), errors, true);
        return errors;
    }
}