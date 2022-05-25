using Bachelor.Thesis.Benchmarking.ParametersPrimitiveTwo;
using Bachelor.Thesis.Benchmarking.WebApi.Repository;
using Microsoft.AspNetCore.Mvc;
using Synnotech.Linq2Db;

namespace Bachelor.Thesis.Benchmarking.WebApi.Database;

public static class AddUserDtoController
{
    public static IServiceCollection AddInsertUserDto(this IServiceCollection services) =>
        services.AddSessionFactoryFor<IAddUserSession, LinqToDbAddUserSession>();

    public static WebApplication MapInsertUserDto(this WebApplication app)
    {
        var defaultUrl = ParametersPrimitiveTwoRepo.Url;

        app.MapPost($"{defaultUrl}light", ([FromServices] ParametersPrimitiveTwoRepo repo, UserDto user) => repo.CreateWithLightValidation(user));
        app.MapPost($"{defaultUrl}fluent", ([FromServices] ParametersPrimitiveTwoRepo repo, UserDto user) => repo.CreateWithFluentValidation(user));
        app.MapPost($"{defaultUrl}model", ([FromServices] ParametersPrimitiveTwoRepo repo, UserDto user) => repo.CreateWithModelValidation(user));

        return app;
    }
}