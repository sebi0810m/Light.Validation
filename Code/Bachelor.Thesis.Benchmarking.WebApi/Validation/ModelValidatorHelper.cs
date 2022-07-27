using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Bachelor.Thesis.Benchmarking.WebApi.Validation;

public static class ModelValidatorHelper
{
    public static List<ValidationResult> PerformValidation<T>(T value)
    {
        var errors = new List<ValidationResult>();
        Validator.TryValidateObject(value!, new ValidationContext(value!), errors, true);
        return errors;
    }

    public static ModelStateDictionary ToModelStateDictionary(this List<ValidationResult> result)
    {
        var modelStateDictionary = new ModelStateDictionary();

        foreach (var item in result)
        {
            modelStateDictionary.AddModelError(item.MemberNames.First()!, item.ErrorMessage!);
        }

        return modelStateDictionary;
    }
}