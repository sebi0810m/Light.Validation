﻿using System.ComponentModel.DataAnnotations;
using Bachelor.Thesis.Benchmarking.CollectionFlat.Validators;
using BenchmarkDotNet.Attributes;

namespace Bachelor.Thesis.Benchmarking.CollectionFlat;

[RPlotExporter]
public class ValidCollectionFlatDtoBenchmarks
{
    public CollectionFlatDto Dto = CollectionFlatDto.ValidDto;

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