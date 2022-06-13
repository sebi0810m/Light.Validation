using LinqToDB;
using LinqToDB.Data;
using Synnotech.Linq2Db;

namespace Bachelor.Thesis.Benchmarking.WebApi.Cases.CollectionFlat;

public class LinqToDbGetCollectionFlatSession : AsyncReadOnlySession, IGetCollectionFlatSession
{
    public LinqToDbGetCollectionFlatSession(DataConnection dataConnection) : base(dataConnection) { }

    public Task<SerializedCollectionFlat?> GetCollectionFlatAsync(Guid customerId) =>
        DataConnection.GetTable<SerializedCollectionFlat>()
                      .FirstOrDefaultAsync(collection => collection.Id == customerId);
}