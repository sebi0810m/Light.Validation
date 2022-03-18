﻿using System.ComponentModel.DataAnnotations;
using BenchmarkDotNet.Attributes;

namespace Bachelor.Thesis.Benchmarking.FlatTwoParametersDto;

public class ValidDtoBenchmarks
{
    public FlatTwoParametersDto Dto = new FlatTwoParametersDto { Id = 42, Name = "John Doe" };
    public ModelValidation DtoModelValidation = new ModelValidation { Id = 42, Name = "John Doe" };
    public FluentValidator FluentValidator = new ();
    public LightValidator LightValidator = new ();

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
    public object? CheckViaModelValidation()
    {
        var errors = new List<ValidationResult>();
        Validator.TryValidateObject(DtoModelValidation, new ValidationContext(DtoModelValidation), errors, true);
        return errors;
    }
}