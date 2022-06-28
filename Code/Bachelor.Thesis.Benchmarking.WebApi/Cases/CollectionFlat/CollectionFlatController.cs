using Bachelor.Thesis.Benchmarking.CollectionFlat;
using Bachelor.Thesis.Benchmarking.CollectionFlat.Validators;
using Synnotech.DatabaseAbstractions;
using Synnotech.Linq2Db;

namespace Bachelor.Thesis.Benchmarking.WebApi.Cases.CollectionFlat;

public static class CollectionFlatController
{
    public static IServiceCollection AddCollectionFlatServices(this IServiceCollection services) =>
        services.AddSingleton<CollectionFlatRepo>()
                .AddSingleton<LightDtoValidator>()
                .AddSingleton<FluentDtoValidator>()
                .AddSessionFactoryFor<IAddCollectionFlatSession, LinqToDbAddCollectionFlatSession>()
                .AddSessionFactoryFor<IGetCollectionFlatSession, LinqToDbGetCollectionFlatSession>();

    public static WebApplication AddCollectionFlatEndpoints(this WebApplication app)
    {
        var defaultUrl = CollectionFlatRepo.Url;

        app.MapPost($"{defaultUrl}light", async (
                        CollectionFlatRepo repo,
                        ISessionFactory<IAddCollectionFlatSession> sessionFactory,
                        LightDtoValidator validator,
                        CollectionFlatDto collectionFlat) => await repo.CreateWithLightValidationAsync(collectionFlat, validator, sessionFactory));
        app.MapPost($"{defaultUrl}fluent", async (
                        CollectionFlatRepo repo,
                        ISessionFactory<IAddCollectionFlatSession> sessionFactory,
                        FluentDtoValidator validator,
                        CollectionFlatDto collectionFlat) => await repo.CreateWithFluentValidationAsync(collectionFlat, validator, sessionFactory));
        app.MapPost($"{defaultUrl}model", async (
                        CollectionFlatRepo repo,
                        ISessionFactory<IAddCollectionFlatSession> sessionFactory,
                        CollectionFlatDto collectionFlat) => await repo.CreateWithModelValidationAsync(collectionFlat, sessionFactory));

        app.MapGet(defaultUrl + "{id:int}", async (
                       CollectionFlatRepo repo,
                       ISessionFactory<IGetCollectionFlatSession> sessionFactory,
                       int id) => await repo.GetObjectByIdAsync(id, sessionFactory));

        return app;
    }
}