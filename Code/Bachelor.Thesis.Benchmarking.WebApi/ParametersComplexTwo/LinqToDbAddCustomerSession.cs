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
        var serializedCustomer = new NewCustomerDto
        {
            CustomerId = customer.CustomerId,
            User = JsonConverter.Serialize(customer.User),
            Address = JsonConverter.Serialize(customer.Address)
        };

        // TestCode for deserializer -> does it work?
        var deserializedCustomer = new CustomerDto
        {
            CustomerId = serializedCustomer.CustomerId,
            User = (User) (JsonConverter.Deserialize(serializedCustomer.User, typeof(User)) ?? new User()),
            Address = (Address) (JsonConverter.Deserialize(serializedCustomer.Address, typeof(Address)) ?? new Address())
        };

        Console.WriteLine("\n\nOriginal Customer object: \n" + customer);
        Console.WriteLine("\n\nNewCustomer object: \n" + serializedCustomer);
        Console.WriteLine("\n\nDeserialized customer object: \n" + deserializedCustomer);

        return DataConnection.InsertWithIdentityAsync(serializedCustomer);
    }
}