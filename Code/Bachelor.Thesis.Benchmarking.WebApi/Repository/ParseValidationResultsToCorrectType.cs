using FluentValidation.Results;
using Light.Validation;
using Microsoft.AspNetCore.Mvc;

namespace Bachelor.Thesis.Benchmarking.WebApi.Repository;

public static class ParseValidationResultsToCorrectType
{
    public static ProblemDetails ParseLightValidationResults<T>(ValidationResult<T> validationResult)
    {
        var problem = new ProblemDetails
        {
            Title = "LightValidation Error",
            Detail = $"Validation not successful. Look into {nameof(validationResult)} for further information",
            Status = 400
        };

        problem.Extensions.Add(nameof(validationResult),
                               validationResult.Errors);

        return problem;
    }

    public static ProblemDetails ParseFluentValidationResults(ValidationResult validationResult)
    {
        var problem = new ProblemDetails
        {
            Title = "FluentValidation Error",
            Detail = $"Validation not successful. Look into {nameof(validationResult)} for further information",
            Status = 400
        };

        problem.Extensions.Add(nameof(validationResult),
                               validationResult.Errors);

        return problem;
    }

    public static ProblemDetails ParseModelValidationResults(List<System.ComponentModel.DataAnnotations.ValidationResult> validationResult)
    {
        var problem = new ProblemDetails
        {
            Title = "ModelValidation Error",
            Detail = $"Validation not successful. Look into {nameof(validationResult)} for further information",
            Status = 400
        };

        problem.Extensions.Add(nameof(validationResult),
                               validationResult);

        return problem;
    }
}