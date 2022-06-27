using System.Data;
using Bachelor.Thesis.Benchmarking.CollectionComplex.Dto;
using LinqToDB;
using LinqToDB.Data;
using Newtonsoft.Json;
using Synnotech.Linq2Db;

namespace Bachelor.Thesis.Benchmarking.WebApi.Cases.CollectionComplex;

public class LinqToDbAddCollectionComplexSession : AsyncSession, IAddCollectionComplexSession
{
    public LinqToDbAddCollectionComplexSession(DataConnection dataConnection) : base(dataConnection) { }

    public Task<object> InsertCollectionComplexAsync(CollectionComplexDto collection)
    {
        var serializedCollectionComplex = new SerializedCollectionComplex
        {
            Id = collection.Guid,
            OrderDetailsList = JsonConvert.SerializeObject(collection.OrderDetailsList),
            ArticleList = JsonConvert.SerializeObject(collection.ArticleList)
        };

        return DataConnection.InsertWithIdentityAsync(serializedCollectionComplex);
    }
}