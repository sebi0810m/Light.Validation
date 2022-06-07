using System.Data;
using Bachelor.Thesis.Benchmarking.ParametersComplexTwo.Dto;
using Bachelor.Thesis.Benchmarking.WebApi.Database;
using LinqToDB;
using LinqToDB.Data;
using Synnotech.Linq2Db;

namespace Bachelor.Thesis.Benchmarking.WebApi.ParametersComplexTwo;

public class LinqToDbAddCustomerSession : AsyncSession, IAddCustomerSession
{
    public LinqToDbAddCustomerSession(DataConnection dataConnection, IsolationLevel transactionLevel = IsolationLevel.Serializable) : base(dataConnection, transactionLevel) { }

    public Task<object> InsertEmployeeAsync(CustomerDto customer)
    {
        var newCustomer = new NewCustomerDto()
        {
            CustomerId = customer.CustomerId
        };

        newCustomer.User = JsonConverter.Serialize(customer.User);
        newCustomer.Address = JsonConverter.Serialize(customer.Address);

        return DataConnection.InsertWithIdentityAsync(customer);
    }
}