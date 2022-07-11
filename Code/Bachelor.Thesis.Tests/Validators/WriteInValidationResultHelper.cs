using System.Collections.Generic;
using System.Linq;
using FluentValidation.Results;
using Light.Validation;
using ModelValidationResult = System.ComponentModel.DataAnnotations.ValidationResult;

namespace Bachelor.Thesis.Tests.Validators;

public static class WriteInValidationResultHelper
{
    public static ValidationResult<T> FluentWriteInLightValidationResult<T>(this ValidationResult result, T value)
    {
        var errors = new Dictionary<string, object>();

        foreach (var error in result.Errors)
        {
            errors.Add(error.PropertyName, error.ErrorMessage);
        }

        return new ValidationResult<T>(value, errors); 
    }

    public static ValidationResult<T> ModelWriteInLightValidationResult<T>(this List<ModelValidationResult> result, T value)
    {
        var errors = new Dictionary<string, object>();

        foreach (var error in result)
        {
            errors.Add(error.MemberNames.FirstOrDefault()!, error.ErrorMessage!);
        }

        return new ValidationResult<T>(value, errors);
    }
}