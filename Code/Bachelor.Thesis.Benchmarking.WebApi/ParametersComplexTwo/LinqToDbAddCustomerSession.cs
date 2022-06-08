using Bachelor.Thesis.Benchmarking.ParametersComplexTwo.Dto;
using LinqToDB;
using LinqToDB.Data;
using Newtonsoft.Json;
using Synnotech.Linq2Db;

namespace Bachelor.Thesis.Benchmarking.WebApi.ParametersComplexTwo;

public class LinqToDbAddCustomerSession : AsyncSession, IAddCustomerSession
{
    public LinqToDbAddCustomerSession(DataConnection dataConnection) : base(dataConnection) { }

    public Task<object> InsertEmployeeAsync(CustomerDto customer)
    {
        var serializedCustomer = new NewCustomerDto
        {
            CustomerId = customer.CustomerId,
            User = JsonConvert.SerializeObject(customer.User),
            Address = JsonConvert.SerializeObject(customer.Address)
        };

        // TestCode for deserializer -> does it work?
        var deserializedCustomer = new CustomerDto
        {
            CustomerId = serializedCustomer.CustomerId,
            User = JsonConvert.DeserializeObject<User>(serializedCustomer.User),
            Address = JsonConvert.DeserializeObject<Address>(serializedCustomer.Address)
        };

        Console.WriteLine("\n\nOriginal Customer object: \n" + customer);
        Console.WriteLine("\n\nNewCustomer object: \n" + serializedCustomer);
        Console.WriteLine("\n\nDeserialized customer object: \n" + deserializedCustomer);
        // end of TestCode

        return DataConnection.InsertWithIdentityAsync(serializedCustomer);
    }
}