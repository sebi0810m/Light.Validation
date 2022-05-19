using Bachelor.Thesis.Benchmarking.ParametersPrimitiveTwo;
using Raven.Client.Documents;

namespace Bachelor.Thesis.Benchmarking.WebApi.Repository;

public static class RavenDbConnector
{
    public static IDocumentStore SetupRavenDbConnection()
    {
        var store = new DocumentStore
        {
            Urls = new[]
            {
                "http://127.0.0.1:1340/"
            },
            Database = "BachelorThesis"
        };

        store.Initialize();

        return store;
    }

    public static UserDto StoreNewUserDtoInDatabase(this UserDto user, IDocumentStore store)
    {
        using var session = store.OpenSession();

        // the id can't be set for complex object --> read documentation
        session.Store(user);

        session.SaveChanges();

        return user;
    }
}