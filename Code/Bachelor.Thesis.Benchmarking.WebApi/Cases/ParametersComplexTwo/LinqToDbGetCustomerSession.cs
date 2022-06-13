using LinqToDB;
using LinqToDB.Data;
using Synnotech.Linq2Db;

namespace Bachelor.Thesis.Benchmarking.WebApi.Cases.ParametersComplexTwo;

public class LinqToDbGetCustomerSession : AsyncReadOnlySession, IGetCustomerSession
{
    public LinqToDbGetCustomerSession(DataConnection dataConnection) : base(dataConnection) { }

    public Task<SerializedCustomerDto?> GetCustomerByIdAsync(Guid customerId) =>
        DataConnection.GetTable<SerializedCustomerDto>()
                      .FirstOrDefaultAsync(customer => customer.CustomerId == customerId);
}