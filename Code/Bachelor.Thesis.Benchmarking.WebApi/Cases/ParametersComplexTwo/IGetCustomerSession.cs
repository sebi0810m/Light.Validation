using Synnotech.DatabaseAbstractions;

namespace Bachelor.Thesis.Benchmarking.WebApi.Cases.ParametersComplexTwo;

public interface IGetCustomerSession : IAsyncReadOnlySession
{
    Task<CustomerEntity?> GetCustomerByIdAsync(Guid customerId);
}