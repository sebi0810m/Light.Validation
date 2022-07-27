using System.ComponentModel.DataAnnotations;
using Bachelor.Thesis.Benchmarking.ParametersPrimitiveTwo.Validators;
using BenchmarkDotNet.Attributes;

namespace Bachelor.Thesis.Benchmarking.ParametersPrimitiveTwo;

[RPlotExporter]
public class ValidUserDtoBenchmarks
{
    public UserDto Dto = UserDto.ValidDto;
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
    public object CheckViaModelValidation()
    {
        var errors = new List<ValidationResult>();
        Validator.TryValidateObject(Dto, new ValidationContext(Dto), errors, true);
        return errors;
    }
}