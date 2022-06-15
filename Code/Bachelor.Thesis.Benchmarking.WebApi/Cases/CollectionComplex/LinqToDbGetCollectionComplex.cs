using LinqToDB;
using LinqToDB.Data;
using Synnotech.Linq2Db;

namespace Bachelor.Thesis.Benchmarking.WebApi.Cases.CollectionComplex;

public class LinqToDbGetCollectionComplex : AsyncReadOnlySession, IGetCollectionComplexSession
{
    public LinqToDbGetCollectionComplex(DataConnection dataConnection) : base(dataConnection) { }

    public Task<SerializedCollectionComplex?> GetCollectionComplexAsync(Guid id) =>
        DataConnection.GetTable<SerializedCollectionComplex>()
                      .FirstOrDefaultAsync(collection => collection.Id == id);
}