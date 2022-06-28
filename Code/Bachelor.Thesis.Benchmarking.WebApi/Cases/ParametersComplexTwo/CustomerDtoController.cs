using Bachelor.Thesis.Benchmarking.ParametersComplexTwo.Dto;
using Bachelor.Thesis.Benchmarking.ParametersComplexTwo.FluentValidator;
using Bachelor.Thesis.Benchmarking.ParametersComplexTwo.LightValidator;
using Microsoft.AspNetCore.Mvc;
using Synnotech.DatabaseAbstractions;
using Synnotech.Linq2Db;

namespace Bachelor.Thesis.Benchmarking.WebApi.Cases.ParametersComplexTwo;

public static class CustomerDtoController
{
    public static IServiceCollection AddCustomerDtoServices(this IServiceCollection services) =>
        services.AddSingleton<ParametersComplexTwoRepo>()
                .AddSingleton<LightDtoValidator>()
                .AddSingleton<FluentDtoValidator>()
                .AddSessionFactoryFor<IAddCustomerSession, LinqToDbAddCustomerSession>()
                .AddSessionFactoryFor<IGetCustomerSession, LinqToDbGetCustomerSession>();

    public static WebApplication AddCustomerDtoEndpoints(this WebApplication app)
    {
        var defaultUrl = ParametersComplexTwoRepo.Url;

        app.MapPost($"{defaultUrl}light", async (
                        ParametersComplexTwoRepo repo,
                        ISessionFactory<IAddCustomerSession> sessionFactory,
                        FluentDtoValidator validator,
                        CustomerDto customer) => await repo.CreateWithLightValidationAsync(customer, validator, sessionFactory));
        app.MapPost($"{defaultUrl}fluent", async (
                        ParametersComplexTwoRepo repo,
                        ISessionFactory<IAddCustomerSession> sessionFactory,
                        FluentDtoValidator validator,
                        CustomerDto customer) => await repo.CreateWithFluentValidationAsync(customer, validator, sessionFactory));
        app.MapPost($"{defaultUrl}model", async (
                        ParametersComplexTwoRepo repo,
                        ISessionFactory<IAddCustomerSession> sessionFactory,
                        CustomerDto customer) => await repo.CreateWithModelValidationAsync(customer, sessionFactory));

        app.MapGet(defaultUrl + "{id:int}", async (
                       ParametersComplexTwoRepo repo,
                       ISessionFactory<IGetCustomerSession> sessionFactory,
                       int id) => await repo.GetObjectByIdAsync(id, sessionFactory));

        return app;
    }
}