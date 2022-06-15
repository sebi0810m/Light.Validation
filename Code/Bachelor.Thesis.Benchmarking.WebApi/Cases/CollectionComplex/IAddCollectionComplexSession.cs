using Bachelor.Thesis.Benchmarking.CollectionComplex.Dto;
using Synnotech.DatabaseAbstractions;

namespace Bachelor.Thesis.Benchmarking.WebApi.Cases.CollectionComplex;

public interface IAddCollectionComplexSession : IAsyncSession
{
    public Task<object> InsertCollectionComplexAsync(CollectionComplexDto collection);
}