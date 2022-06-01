using Bachelor.Thesis.Benchmarking.ParametersPrimitiveTwo;
using Microsoft.AspNetCore.Mvc;
using Synnotech.DatabaseAbstractions;
using Synnotech.Linq2Db;

namespace Bachelor.Thesis.Benchmarking.WebApi.ParametersPrimitiveTwo;

public static class UserDtoController
{
    public static IServiceCollection AddUserDtoServices(this IServiceCollection services) =>
        services.AddSessionFactoryFor<IAddUserSession, LinqToDbAddUserSession>()
                .AddSessionFactoryFor<IGetUserSession, LinqToDbGetUserSession>();

    public static WebApplication MapUserDtoEndpoints(this WebApplication app)
    {
        var defaultUrl = ParametersPrimitiveTwoRepo.Url;

        app.MapPost($"{defaultUrl}light", async (
                        [FromServices] ParametersPrimitiveTwoRepo repo,
                        [FromServices] ISessionFactory<IAddUserSession> sessionFactory,
                        [FromBody] UserDto user) => await repo.CreateWithLightValidation(user, sessionFactory));
        app.MapPost($"{defaultUrl}fluent", async (
                        [FromServices] ParametersPrimitiveTwoRepo repo,
                        [FromServices] ISessionFactory<IAddUserSession> sessionFactory,
                        [FromBody] UserDto user) => await repo.CreateWithFluentValidation(user, sessionFactory));
        app.MapPost($"{defaultUrl}model", async (
                        [FromServices] ParametersPrimitiveTwoRepo repo,
                        [FromServices] ISessionFactory<IAddUserSession> sessionFactory,
                        [FromBody] UserDto user) => await repo.CreateWithModelValidation(user, sessionFactory));

        app.MapGet(defaultUrl + "{id}", async (
                       [FromServices] ParametersPrimitiveTwoRepo repo,
                       [FromServices] ISessionFactory<IGetUserSession> sessionFactory,
                       int id) => await repo.GetUserById(id, sessionFactory));

        return app;
    }
}