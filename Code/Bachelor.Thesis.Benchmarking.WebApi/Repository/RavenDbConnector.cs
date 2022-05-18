using Bachelor.Thesis.Benchmarking.ParametersPrimitiveTwo;
using Raven.Client.Documents;

namespace Bachelor.Thesis.Benchmarking.WebApi.Repository;

public static class RavenDbConnector
{
    public static IDocumentStore SetupRavenDbConnection()
    {
        using var store = new DocumentStore
        {
            Urls = new[]
            {
                "http://127.0.0.1:1337/"
            },
            Database = "Northwind"
        };

        store.Initialize();

        return store;
    }

    public static UserDto StoreNewUserDtoInDatabase(this UserDto user, IDocumentStore store)
    {
        using var session = store.OpenSession();

        session.Store(user);

        return user;
    }
}