using Bachelor.Thesis.Benchmarking.CollectionFlat;
using LinqToDB;
using LinqToDB.Data;
using Newtonsoft.Json;
using Synnotech.Linq2Db;

namespace Bachelor.Thesis.Benchmarking.WebApi.Cases.CollectionFlat;

public class LinqToDbAddCollectionFlatSession : AsyncSession, IAddCollectionFlatSession
{
    public LinqToDbAddCollectionFlatSession(DataConnection dataConnection) : base(dataConnection) { }

    public Task<object> InsertCollectionFlatAsync(CollectionFlatDto collection)
    {
        var serializedCollectionFlat = new CollectionFlatEntity
        {
            Id = collection.Guid,
            Names = JsonConvert.SerializeObject(collection.Names),
            Availability = JsonConvert.SerializeObject(collection.Availability)
        };

        return DataConnection.InsertWithIdentityAsync(serializedCollectionFlat);
    }
}