using Bachelor.Thesis.Benchmarking.ParametersComplexTwo.Dto;
using Microsoft.AspNetCore.Mvc;
using Synnotech.DatabaseAbstractions;
using Synnotech.Linq2Db;

namespace Bachelor.Thesis.Benchmarking.WebApi.Cases.ParametersComplexTwo;

public static class CustomerDtoController
{
    public static IServiceCollection AddCustomerDtoServices(this IServiceCollection services) =>
        services.AddSingleton<ParametersComplexTwoRepo>()
                .AddSessionFactoryFor<IAddCustomerSession, LinqToDbAddCustomerSession>()
                .AddSessionFactoryFor<IGetCustomerSession, LinqToDbGetCustomerSession>();

    public static WebApplication AddCustomerDtoEndpoints(this WebApplication app)
    {
        var defaultUrl = ParametersComplexTwoRepo.Url;

        app.MapPost($"{defaultUrl}light", async (
                        [FromServices] ParametersComplexTwoRepo repo,
                        [FromServices] ISessionFactory<IAddCustomerSession> sessionFactory,
                        [FromBody] CustomerDto customer) => await repo.CreateWithLightValidationAsync(customer, sessionFactory));
        app.MapPost($"{defaultUrl}fluent", async (
                        [FromServices] ParametersComplexTwoRepo repo,
                        [FromServices] ISessionFactory<IAddCustomerSession> sessionFactory,
                        [FromBody] CustomerDto customer) => await repo.CreateWithFluentValidationAsync(customer, sessionFactory));
        app.MapPost($"{defaultUrl}model", async (
                        [FromServices] ParametersComplexTwoRepo repo,
                        [FromServices] ISessionFactory<IAddCustomerSession> sessionFactory,
                        [FromBody] CustomerDto customer) => await repo.CreateWithModelValidationAsync(customer, sessionFactory));

        app.MapGet(defaultUrl + "{id:guid}", async (
                       [FromServices] ParametersComplexTwoRepo repo,
                       [FromServices] ISessionFactory<IGetCustomerSession> sessionFactory,
                       Guid id) => await repo.GetObjectByIdAsync(id, sessionFactory));

        return app;
    }
}