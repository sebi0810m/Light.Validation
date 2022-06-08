using System.Data;
using Bachelor.Thesis.Benchmarking.ParametersComplexTwo.Dto;
using LinqToDB.Data;
using Synnotech.Linq2Db;

namespace Bachelor.Thesis.Benchmarking.WebApi.ParametersComplexTwo;

public class LinqToDbGetCustomerSession : AsyncReadOnlySession, IGetCustomerSession
{
    public LinqToDbGetCustomerSession(DataConnection dataConnection) : base(dataConnection) { }
    public Task<CustomerDto?> GetEmployeeByIdAsync(Guid employeeId)
    {
        throw new NotImplementedException();
    }
}