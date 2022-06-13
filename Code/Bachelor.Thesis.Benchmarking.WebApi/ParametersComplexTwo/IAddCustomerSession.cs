using Bachelor.Thesis.Benchmarking.ParametersComplexTwo.Dto;
using Synnotech.DatabaseAbstractions;

namespace Bachelor.Thesis.Benchmarking.WebApi.ParametersComplexTwo;

public interface IAddCustomerSession : IAsyncSession
{
    public Task<object> InsertCustomerAsync(CustomerDto customer);
}