using Bachelor.Thesis.Benchmarking.ParametersPrimitiveAll;
using Microsoft.AspNetCore.Mvc;
using Synnotech.DatabaseAbstractions;
using Synnotech.Linq2Db;

namespace Bachelor.Thesis.Benchmarking.WebApi.ParametersPrimitiveAll;

public static class EmployeeDtoController
{
    public static IServiceCollection AddEmployeeDtoServices(this IServiceCollection services) =>
        services.AddSessionFactoryFor<IAddEmployeeSession, LinqToDbAddEmployeeSession>();

    public static WebApplication AddEmployeeDtoEndpoints(this WebApplication app)
    {
        var defaultUrl = ParametersPrimitiveAllRepo.Url;

        app.MapPost($"{defaultUrl}fluent", async (
                        [FromServices] ParametersPrimitiveAllRepo repo,
                        [FromServices] ISessionFactory<IAddEmployeeSession> sessionFactory,
                        [FromBody] EmployeeDto employee) => await repo.CreateWithFluentValidationAsync(employee, sessionFactory));

        return app;
    }
}