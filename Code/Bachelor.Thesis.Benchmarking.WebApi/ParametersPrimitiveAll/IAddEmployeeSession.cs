using Bachelor.Thesis.Benchmarking.ParametersPrimitiveAll;
using Synnotech.DatabaseAbstractions;

namespace Bachelor.Thesis.Benchmarking.WebApi.ParametersPrimitiveAll;

public interface IAddEmployeeSession : IAsyncSession
{
    public Task<Guid> InsertEmployeeAsync(EmployeeDto employee);
}