using FluentValidation.Results;
using Light.Validation;
using Microsoft.AspNetCore.Mvc;

namespace Bachelor.Thesis.Benchmarking.WebApi.Repository;

public static class ParseValidationResultsToCorrectType
{
    public static ProblemDetails ParseLightValidationResults<T>(ValidationResult<T> validationResult)
    {
        return new ProblemDetails();
    }

    public static ProblemDetails ParseFluentValidationResults(ValidationResult validationResult)
    {
        return new ProblemDetails();
    }

    public static ProblemDetails ParseModelValidationResults(List<ValidationResult> validationResult)
    {
        return new ProblemDetails();
    }
}