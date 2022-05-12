using Bachelor.Thesis.Benchmarking.ParametersPrimitiveTwo;
using Bachelor.Thesis.Benchmarking.WebApi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Bachelor.Thesis.Benchmarking.WebApi;

public static class AddRoutingForValidators
{
    private static readonly string DefaultUrl = ParametersPrimitiveTwoRepo.Url;

    public static WebApplication AddRoutingForParametersPrimitiveTwo(this WebApplication app)
    {
        app.MapPost($"{DefaultUrl}light", ([FromServices] ParametersPrimitiveTwoRepo repo, UserDto user) => repo.CreateWithLightValidation(user));
        app.MapPost($"{DefaultUrl}fluent", ([FromServices] ParametersPrimitiveTwoRepo repo, UserDto user) => repo.CreateWithFluentValidation(user));
        app.MapPost($"{DefaultUrl}model", ([FromServices] ParametersPrimitiveTwoRepo repo, UserDto user) => repo.CreateWithModelValidation(user));

        return app;
    }

    /*public static WebApplication AddRoutingForParametersPrimitiveAll(this WebApplication app)
    {
        app.MapPost($"{DefaultUrl}light", ([FromServices] ParametersPrimitiveTwoRepo repo, UserDto user) => repo.CreateWithLightValidation(user));
        app.MapPost($"{DefaultUrl}fluent", ([FromServices] ParametersPrimitiveTwoRepo repo, UserDto user) => repo.CreateWithFluentValidation(user));
        app.MapPost($"{DefaultUrl}model", ([FromServices] ParametersPrimitiveTwoRepo repo, UserDto user) => repo.CreateWithModelValidation(user));

        return app;
    }*/
}