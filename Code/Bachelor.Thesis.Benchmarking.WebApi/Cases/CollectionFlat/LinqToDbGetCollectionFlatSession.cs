using LinqToDB;
using LinqToDB.Data;
using Synnotech.Linq2Db;

namespace Bachelor.Thesis.Benchmarking.WebApi.Cases.CollectionFlat;

public class LinqToDbGetCollectionFlatSession : AsyncReadOnlySession, IGetCollectionFlatSession
{
    public LinqToDbGetCollectionFlatSession(DataConnection dataConnection) : base(dataConnection) { }

    public Task<CollectionFlatEntity?> GetCollectionFlatByIdAsync(int id) =>
        DataConnection.GetTable<CollectionFlatEntity>()
                      .FirstOrDefaultAsync(collection => collection.Id == id);
}