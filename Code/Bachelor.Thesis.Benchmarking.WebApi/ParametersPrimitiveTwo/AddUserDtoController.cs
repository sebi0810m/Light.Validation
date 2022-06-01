﻿using Bachelor.Thesis.Benchmarking.ParametersPrimitiveTwo;
using Microsoft.AspNetCore.Mvc;
using Synnotech.DatabaseAbstractions;
using Synnotech.Linq2Db;

namespace Bachelor.Thesis.Benchmarking.WebApi.ParametersPrimitiveTwo;

public static class AddUserDtoController
{
    public static IServiceCollection AddInsertUserDto(this IServiceCollection services) =>
        services.AddSessionFactoryFor<IAddUserSession, LinqToDbAddUserSession>();

    public static WebApplication MapInsertUserDto(this WebApplication app)
    {
        var defaultUrl = ParametersPrimitiveTwoRepo.Url;

        app.MapPost($"{defaultUrl}light", (
                        [FromServices] ParametersPrimitiveTwoRepo repo,
                        [FromServices] ISessionFactory<IAddUserSession> sessionFactory,
                        [FromBody] UserDto user) => repo.CreateWithLightValidation(user, sessionFactory));
        app.MapPost($"{defaultUrl}fluent", (
                        [FromServices] ParametersPrimitiveTwoRepo repo,
                        [FromServices] ISessionFactory<IAddUserSession> sessionFactory,
                        [FromBody] UserDto user) => repo.CreateWithFluentValidation(user, sessionFactory));
        app.MapPost($"{defaultUrl}model", (
                        [FromServices] ParametersPrimitiveTwoRepo repo,
                        [FromServices] ISessionFactory<IAddUserSession> sessionFactory,
                        [FromBody] UserDto user) => repo.CreateWithModelValidation(user, sessionFactory));

        return app;
    }
}