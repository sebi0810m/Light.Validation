using System.Collections.Generic;
using System.Linq;
using FluentValidation.Results;
using Light.Validation;
using ModelValidationResult = System.ComponentModel.DataAnnotations.ValidationResult;

namespace Bachelor.Thesis.Tests.Validators;

public static class WriteInValidationResultHelper
{
    private static readonly Dictionary<string, string> Errors = new ();

    public static ValidationResult<T> FluentWriteInLightValidationResult<T>(this ValidationResult result, T value)
    {
        if(Errors.Count > 0) 
            Errors.Clear();

        foreach (var error in result.Errors)
        {
            Errors.Add(error.PropertyName, error.ErrorMessage);
        }

        return new ValidationResult<T>(value, Errors); 
    }

    public static ValidationResult<T> ModelWriteInLightValidationResult<T>(this List<ModelValidationResult> result, T value)
    {
        if (Errors.Count > 0)
            Errors.Clear();

        foreach (var error in result)
        {
            Errors.Add(error.MemberNames.FirstOrDefault()!, error.ErrorMessage!);
        }

        return new ValidationResult<T>(value, Errors);
    }
}