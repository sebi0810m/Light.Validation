using System.Text.Json;
using Bachelor.Thesis.Benchmarking.CollectionFlat;
using LinqToDB;
using LinqToDB.Data;
using Synnotech.Linq2Db;

namespace Bachelor.Thesis.Benchmarking.WebApi.Cases.CollectionFlat;

public class LinqToDbAddCollectionFlatSession : AsyncSession, IAddCollectionFlatSession
{
    public LinqToDbAddCollectionFlatSession(DataConnection dataConnection) : base(dataConnection) { }

    public Task<int> InsertCollectionFlatAsync(CollectionFlatDto collection)
    {
        var serializedCollectionFlat = new CollectionFlatEntity
        {
            Id = collection.Id,
            Guid = collection.Guid,
            Names = JsonSerializer.Serialize(collection.Names),
            Availability = JsonSerializer.Serialize(collection.Availability)
        };

        return DataConnection.InsertWithInt32IdentityAsync(serializedCollectionFlat);
    }
}