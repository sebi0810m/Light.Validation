using Bachelor.Thesis.Benchmarking.ParametersComplexTwo.Dto;
using Synnotech.DatabaseAbstractions;

namespace Bachelor.Thesis.Benchmarking.WebApi.ParametersComplexTwo;

public interface IGetCustomerSession : IAsyncReadOnlySession
{
    Task<CustomerDto?> GetCustomerByIdAsync(Guid customerId);
}