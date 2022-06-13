using Bachelor.Thesis.Benchmarking.ParametersPrimitiveAll;
using Synnotech.DatabaseAbstractions;

namespace Bachelor.Thesis.Benchmarking.WebApi.Cases.ParametersPrimitiveAll;

public interface IGetEmployeeSession : IAsyncReadOnlySession
{
    Task<EmployeeDto?> GetEmployeeByIdAsync(Guid employeeId);
}