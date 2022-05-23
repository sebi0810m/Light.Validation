using Bachelor.Thesis.Benchmarking.ParametersPrimitiveTwo;
using Bachelor.Thesis.Benchmarking.WebApi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Bachelor.Thesis.Benchmarking.WebApi;

public static class AddRoutingForValidators
{
    public static WebApplication AddRoutingForParametersPrimitiveTwo(this WebApplication app)
    {
        var defaultUrl = ParametersPrimitiveTwoRepo.Url;

        app.MapPost($"{defaultUrl}light", ([FromServices] ParametersPrimitiveTwoRepo repo, UserDto user) => repo.CreateWithLightValidation(user));
        app.MapPost($"{defaultUrl}fluent", ([FromServices] ParametersPrimitiveTwoRepo repo, UserDto user) => repo.CreateWithFluentValidation(user));
        app.MapPost($"{defaultUrl}model", ([FromServices] ParametersPrimitiveTwoRepo repo, UserDto user) => repo.CreateWithModelValidation(user));

        return app;
    }
}