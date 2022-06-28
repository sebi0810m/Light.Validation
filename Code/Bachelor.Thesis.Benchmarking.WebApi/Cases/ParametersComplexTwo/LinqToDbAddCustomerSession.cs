using System.Text.Json;
using Bachelor.Thesis.Benchmarking.ParametersComplexTwo.Dto;
using LinqToDB;
using LinqToDB.Data;
using Synnotech.Linq2Db;

namespace Bachelor.Thesis.Benchmarking.WebApi.Cases.ParametersComplexTwo;

public class LinqToDbAddCustomerSession : AsyncSession, IAddCustomerSession
{
    public LinqToDbAddCustomerSession(DataConnection dataConnection) : base(dataConnection) { }

    public Task<int> InsertCustomerAsync(CustomerDto customer)
    {
        var serializedCustomer = new CustomerEntity
        {
            Guid = customer.Guid,
            User = JsonSerializer.Serialize(customer.User),
            Address = JsonSerializer.Serialize(customer.Address)
        };
        
        return DataConnection.InsertWithInt32IdentityAsync(serializedCustomer);
    }
}