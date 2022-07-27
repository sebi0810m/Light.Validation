using Bachelor.Thesis.Benchmarking.ParametersPrimitiveAll;
using Bachelor.Thesis.Benchmarking.ParametersPrimitiveAll.Validators;
using Microsoft.AspNetCore.Mvc;
using Synnotech.DatabaseAbstractions;
using Synnotech.Linq2Db;

namespace Bachelor.Thesis.Benchmarking.WebApi.Cases.ParametersPrimitiveAll;

public static class EmployeeDtoController
{
    public static IServiceCollection AddEmployeeDtoServices(this IServiceCollection services) =>
        services.AddSingleton<ParametersPrimitiveAllRepo>()
                .AddSingleton<LightValidator>()
                .AddSingleton<FluentValidator>()
                .AddSessionFactoryFor<IAddEmployeeSession, LinqToDbAddEmployeeSession>()
                .AddSessionFactoryFor<IGetEmployeeSession, LinqToDbGetEmployeeSession>();

    public static WebApplication AddEmployeeDtoEndpoints(this WebApplication app)
    {
        var defaultUrl = ParametersPrimitiveAllRepo.Url;

        app.MapPost($"{defaultUrl}light", async (
                        ParametersPrimitiveAllRepo repo,
                        ISessionFactory<IAddEmployeeSession> sessionFactory,
                        LightValidator validator,
                        EmployeeDto employee) => await repo.CreateWithLightValidationAsync(employee, validator, sessionFactory));
        app.MapPost($"{defaultUrl}fluent", async (
                        ParametersPrimitiveAllRepo repo,
                        ISessionFactory<IAddEmployeeSession> sessionFactory,
                        FluentValidator validator,
                        EmployeeDto employee) => await repo.CreateWithFluentValidationAsync(employee, validator, sessionFactory));
        app.MapPost($"{defaultUrl}model", async (
                        ParametersPrimitiveAllRepo repo,
                        ISessionFactory<IAddEmployeeSession> sessionFactory,
                        EmployeeDto employee) => await repo.CreateWithModelValidationAsync(employee, sessionFactory));

        app.MapGet(defaultUrl + "{id:int}", async (
                       ParametersPrimitiveAllRepo repo,
                       ISessionFactory<IGetEmployeeSession> sessionFactory,
                       int id) => await repo.GetObjectByIdAsync(id, sessionFactory));

        return app;
    }
}