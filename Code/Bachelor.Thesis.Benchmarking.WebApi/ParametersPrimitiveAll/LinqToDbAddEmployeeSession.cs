using System.Data;
using Bachelor.Thesis.Benchmarking.ParametersPrimitiveAll;
using LinqToDB;
using LinqToDB.Data;
using Synnotech.Linq2Db;

namespace Bachelor.Thesis.Benchmarking.WebApi.ParametersPrimitiveAll;

public class LinqToDbAddEmployeeSession : AsyncSession, IAddEmployeeSession
{
    public LinqToDbAddEmployeeSession(DataConnection dataConnection) : base(dataConnection) { }

    public Task<Guid> InsertEmployeeAsync(EmployeeDto employee)
    {
        return DataConnection.InsertWithIdentityAsync(employee).ContinueWith(task => (Guid) task.Result);
    }
}