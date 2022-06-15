using Bachelor.Thesis.Benchmarking.ParametersPrimitiveAll;
using Microsoft.AspNetCore.Mvc;
using Synnotech.DatabaseAbstractions;
using Synnotech.Linq2Db;

namespace Bachelor.Thesis.Benchmarking.WebApi.Cases.ParametersPrimitiveAll;

public static class EmployeeDtoController
{
    public static IServiceCollection AddEmployeeDtoServices(this IServiceCollection services) =>
        services.AddSingleton<ParametersPrimitiveAllRepo>()
                .AddSessionFactoryFor<IAddEmployeeSession, LinqToDbAddEmployeeSession>()
                .AddSessionFactoryFor<IGetEmployeeSession, LinqToDbGetEmployeeSession>();

    public static WebApplication AddEmployeeDtoEndpoints(this WebApplication app)
    {
        var defaultUrl = ParametersPrimitiveAllRepo.Url;

        app.MapPost($"{defaultUrl}light", async (
                        [FromServices] ParametersPrimitiveAllRepo repo,
                        [FromServices] ISessionFactory<IAddEmployeeSession> sessionFactory,
                        [FromBody] EmployeeDto employee) => await repo.CreateWithLightValidationAsync(employee, sessionFactory));
        app.MapPost($"{defaultUrl}fluent", async (
                        [FromServices] ParametersPrimitiveAllRepo repo,
                        [FromServices] ISessionFactory<IAddEmployeeSession> sessionFactory,
                        [FromBody] EmployeeDto employee) => await repo.CreateWithFluentValidationAsync(employee, sessionFactory));
        app.MapPost($"{defaultUrl}model", async (
                        [FromServices] ParametersPrimitiveAllRepo repo,
                        [FromServices] ISessionFactory<IAddEmployeeSession> sessionFactory,
                        [FromBody] EmployeeDto employee) => await repo.CreateWithModelValidationAsync(employee, sessionFactory));

        app.MapGet(defaultUrl + "{id:guid}", async (
                       [FromServices] ParametersPrimitiveAllRepo repo,
                       [FromServices] ISessionFactory<IGetEmployeeSession> sessionFactory,
                       Guid id) => await repo.GetObjectByIdAsync(id, sessionFactory));

        return app;
    }
}