using Bachelor.Thesis.Benchmarking.CollectionFlat;
using Microsoft.AspNetCore.Mvc;
using Synnotech.DatabaseAbstractions;
using Synnotech.Linq2Db;

namespace Bachelor.Thesis.Benchmarking.WebApi.Cases.CollectionFlat;

public static class CollectionFlatController
{
    public static IServiceCollection AddCollectionFlatServices(this IServiceCollection services) =>
        services.AddSingleton<CollectionFlatRepo>()
                .AddSessionFactoryFor<IAddCollectionFlatSession, LinqToDbAddCollectionFlatSession>()
                .AddSessionFactoryFor<IGetCollectionFlatSession, LinqToDbGetCollectionFlatSession>();

    public static WebApplication AddCollectionFlatEndpoints(this WebApplication app)
    {
        var defaultUrl = CollectionFlatRepo.Url;

        app.MapPost($"{defaultUrl}light", async (
                        [FromServices] CollectionFlatRepo repo,
                        [FromServices] ISessionFactory<IAddCollectionFlatSession> sessionFactory,
                        [FromBody] CollectionFlatDto collectionFlat) => await repo.CreateWithLightValidationAsync(collectionFlat, sessionFactory));
        app.MapPost($"{defaultUrl}fluent", async (
                        [FromServices] CollectionFlatRepo repo,
                        [FromServices] ISessionFactory<IAddCollectionFlatSession> sessionFactory,
                        [FromBody] CollectionFlatDto collectionFlat) => await repo.CreateWithFluentValidationAsync(collectionFlat, sessionFactory));
        app.MapPost($"{defaultUrl}model", async (
                        [FromServices] CollectionFlatRepo repo,
                        [FromServices] ISessionFactory<IAddCollectionFlatSession> sessionFactory,
                        [FromBody] CollectionFlatDto collectionFlat) => await repo.CreateWithModelValidationAsync(collectionFlat, sessionFactory));

        app.MapGet(defaultUrl + "{id}", async (
                       [FromServices] CollectionFlatRepo repo,
                       [FromServices] ISessionFactory<IGetCollectionFlatSession> sessionFactory,
                       Guid id) => await repo.GetObjectByIdAsync(id, sessionFactory));

        return app;
    }
}