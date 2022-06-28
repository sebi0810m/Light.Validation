using Bachelor.Thesis.Benchmarking.ParametersPrimitiveTwo;
using Bachelor.Thesis.Benchmarking.ParametersPrimitiveTwo.Validators;
using Microsoft.AspNetCore.Mvc;
using Synnotech.DatabaseAbstractions;
using Synnotech.Linq2Db;

namespace Bachelor.Thesis.Benchmarking.WebApi.Cases.ParametersPrimitiveTwo;

public static class UserDtoController
{
    public static IServiceCollection AddUserDtoServices(this IServiceCollection services) =>
        services.AddSingleton<ParametersPrimitiveTwoRepo>()
                .AddSingleton<LightValidator>()
                .AddSingleton<FluentValidator>()
                .AddSessionFactoryFor<IAddUserSession, LinqToDbAddUserSession>()
                .AddSessionFactoryFor<IGetUserSession, LinqToDbGetUserSession>();

    public static WebApplication MapUserDtoEndpoints(this WebApplication app)
    {
        var defaultUrl = ParametersPrimitiveTwoRepo.Url;

        app.MapPost($"{defaultUrl}light", async (
                        ParametersPrimitiveTwoRepo repo,
                        ISessionFactory<IAddUserSession> sessionFactory,
                        LightValidator validator,
                        UserDto user) => await repo.CreateWithLightValidationAsync(user, validator, sessionFactory));
        app.MapPost($"{defaultUrl}fluent", async (
                        ParametersPrimitiveTwoRepo repo,
                        ISessionFactory<IAddUserSession> sessionFactory,
                        FluentValidator validator,
                        UserDto user) => await repo.CreateWithFluentValidationAsync(user, validator, sessionFactory));
        app.MapPost($"{defaultUrl}model", async (
                        ParametersPrimitiveTwoRepo repo,
                        ISessionFactory<IAddUserSession> sessionFactory,
                        UserDto user) => await repo.CreateWithModelValidationAsync(user, sessionFactory));

        app.MapGet(defaultUrl + "{id:int}", async (
                       [FromServices] ParametersPrimitiveTwoRepo repo,
                       [FromServices] ISessionFactory<IGetUserSession> sessionFactory,
                       int id) => await repo.GetObjectByIdAsync(id, sessionFactory));

        return app;
    }
}