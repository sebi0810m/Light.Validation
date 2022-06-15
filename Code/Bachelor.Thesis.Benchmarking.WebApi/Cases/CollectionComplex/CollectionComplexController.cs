using Bachelor.Thesis.Benchmarking.CollectionComplex.Dto;
using Microsoft.AspNetCore.Mvc;
using Synnotech.DatabaseAbstractions;
using Synnotech.Linq2Db;

namespace Bachelor.Thesis.Benchmarking.WebApi.Cases.CollectionComplex;

public static class CollectionComplexController
{
    public static IServiceCollection AddCollectionComplexServices(this IServiceCollection services) =>
        services.AddSingleton<CollectionComplexRepo>()
                .AddSessionFactoryFor<IAddCollectionComplexSession, LinqToDbAddCollectionComplexSession>()
                .AddSessionFactoryFor<IGetCollectionComplexSession, LinqToDbGetCollectionComplex>();

    public static WebApplication AddCollectionComplexEndpoints(this WebApplication app)
    {
        var defaultUrl = CollectionComplexRepo.Url;

        app.MapPost($"{defaultUrl}light", async (
                        [FromServices] CollectionComplexRepo repo,
                        [FromServices] ISessionFactory<IAddCollectionComplexSession> sessionFactory,
                        [FromBody] CollectionComplexDto collectionComplex) => await repo.CreateWithLightValidationAsync(collectionComplex, sessionFactory));

        app.MapPost($"{defaultUrl}fluent", async (
                        [FromServices] CollectionComplexRepo repo,
                        [FromServices] ISessionFactory<IAddCollectionComplexSession> sessionFactory,
                        [FromBody] CollectionComplexDto collectionComplex) => await repo.CreateWithFluentValidationAsync(collectionComplex, sessionFactory));

        app.MapPost($"{defaultUrl}model", async (
                        [FromServices] CollectionComplexRepo repo,
                        [FromServices] ISessionFactory<IAddCollectionComplexSession> sessionFactory,
                        [FromBody] CollectionComplexDto collectionComplex) => await repo.CreateWithModelValidationAsync(collectionComplex, sessionFactory));

        app.MapGet(defaultUrl + "{id:guid}", async (
                       [FromServices] CollectionComplexRepo repo,
                       [FromServices] ISessionFactory<IGetCollectionComplexSession> sessionFactory,
                       Guid id) => await repo.GetObjectByIdAsync(id, sessionFactory));

        return app;
    }
}