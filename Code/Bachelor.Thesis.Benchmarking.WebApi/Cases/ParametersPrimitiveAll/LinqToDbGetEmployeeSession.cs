using Bachelor.Thesis.Benchmarking.ParametersPrimitiveAll;
using LinqToDB;
using LinqToDB.Data;
using Synnotech.Linq2Db;

namespace Bachelor.Thesis.Benchmarking.WebApi.Cases.ParametersPrimitiveAll;

public class LinqToDbGetEmployeeSession : AsyncReadOnlySession, IGetEmployeeSession
{
    public LinqToDbGetEmployeeSession(DataConnection dataConnection) : base(dataConnection) { }

    public Task<EmployeeDto?> GetEmployeeByIdAsync(Guid employeeId) =>
        DataConnection.GetTable<EmployeeDto>()
                      .FirstOrDefaultAsync(employee => employee.Id == employeeId);
}