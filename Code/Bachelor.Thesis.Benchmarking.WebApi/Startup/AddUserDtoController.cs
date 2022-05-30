using Bachelor.Thesis.Benchmarking.ParametersPrimitiveTwo;
using Bachelor.Thesis.Benchmarking.WebApi.Database;
using Bachelor.Thesis.Benchmarking.WebApi.Repository;
using Microsoft.AspNetCore.Mvc;
using Synnotech.DatabaseAbstractions;
using Synnotech.Linq2Db;

namespace Bachelor.Thesis.Benchmarking.WebApi.Startup;

public static class AddUserDtoController
{
    public static IServiceCollection AddInsertUserDto(this IServiceCollection services) =>
        services.AddSessionFactoryFor<IAddUserSession, LinqToDbAddUserSession>();

    public static WebApplication MapInsertUserDto(this WebApplication app)
    {
        var defaultUrl = ParametersPrimitiveTwoRepo.Url;

        app.MapPost($"{defaultUrl}light", ([FromServices] ParametersPrimitiveTwoRepo repo, UserDto user) => repo.CreateWithLightValidation(user));
        app.MapPost($"{defaultUrl}fluent", (
                        [FromServices] ParametersPrimitiveTwoRepo repo,
                        [FromServices] ISessionFactory<IAddUserSession> sessionFactory,
                        UserDto user) => repo.CreateWithFluentValidation(user, sessionFactory));
        app.MapPost($"{defaultUrl}model", ([FromServices] ParametersPrimitiveTwoRepo repo, UserDto user) => repo.CreateWithModelValidation(user));

        return app;
    }
}