using FluentValidation.AspNetCore;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Bachelor.Thesis.Benchmarking.WebApi.Validation;

public static class FluentValidatorHelper
{
    public static ModelStateDictionary ToModelStateDictionary(this ValidationResult result)
    {
        var modelStateDictionary = new ModelStateDictionary();
        result.AddToModelState(modelStateDictionary, string.Empty);
        return modelStateDictionary;
    }
}