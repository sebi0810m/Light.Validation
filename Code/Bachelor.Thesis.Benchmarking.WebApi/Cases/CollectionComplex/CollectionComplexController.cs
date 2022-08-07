using Bachelor.Thesis.Benchmarking.CollectionComplex.Dto;
using Bachelor.Thesis.Benchmarking.CollectionComplex.FluentValidation;
using Bachelor.Thesis.Benchmarking.CollectionComplex.LightValidation;
using Synnotech.DatabaseAbstractions;
using Synnotech.Linq2Db;

namespace Bachelor.Thesis.Benchmarking.WebApi.Cases.CollectionComplex;

public static class CollectionComplexController
{
    public static IServiceCollection AddCollectionComplexServices(this IServiceCollection services) =>
        services.AddSingleton<CollectionComplexRepo>()
                .AddSingleton<LightDtoValidator>()
                .AddSingleton<FluentDtoValidator>()
                .AddSessionFactoryFor<IAddCollectionComplexSession, LinqToDbAddCollectionComplexSession>()
                .AddSessionFactoryFor<IGetCollectionComplexSession, LinqToDbGetCollectionComplex>();

    public static WebApplication AddCollectionComplexEndpoints(this WebApplication app)
    {
        var defaultUrl = CollectionComplexRepo.Url;

        app.MapPost($"{defaultUrl}light", async (
                        CollectionComplexRepo repo,
                        ISessionFactory<IAddCollectionComplexSession> sessionFactory,
                        LightDtoValidator validator,
                        CollectionComplexDto collectionComplex) => await repo.CreateWithLightValidationAsync(collectionComplex, validator, sessionFactory));

        app.MapPost($"{defaultUrl}fluent", async (
                        CollectionComplexRepo repo,
                        ISessionFactory<IAddCollectionComplexSession> sessionFactory,
                        FluentDtoValidator validator,
                        CollectionComplexDto collectionComplex) => await repo.CreateWithFluentValidationAsync(collectionComplex, validator, sessionFactory));

        app.MapPost($"{defaultUrl}model", async (
                        CollectionComplexRepo repo,
                        ISessionFactory<IAddCollectionComplexSession> sessionFactory,
                        CollectionComplexDto collectionComplex) => await repo.CreateWithModelValidationAsync(collectionComplex, sessionFactory));

        app.MapGet(defaultUrl + "{id:int}", async (
                       CollectionComplexRepo repo,
                       ISessionFactory<IGetCollectionComplexSession> sessionFactory,
                       int id) => await repo.GetObjectByIdAsync(id, sessionFactory));

        return app;
    }
}