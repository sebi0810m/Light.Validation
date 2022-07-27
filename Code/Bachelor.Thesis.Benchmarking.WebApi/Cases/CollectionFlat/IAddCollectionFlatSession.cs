using Bachelor.Thesis.Benchmarking.CollectionFlat;
using Synnotech.DatabaseAbstractions;

namespace Bachelor.Thesis.Benchmarking.WebApi.Cases.CollectionFlat;

public interface IAddCollectionFlatSession : IAsyncSession
{
    public Task<int> InsertCollectionFlatAsync(CollectionFlatDto collection);
}