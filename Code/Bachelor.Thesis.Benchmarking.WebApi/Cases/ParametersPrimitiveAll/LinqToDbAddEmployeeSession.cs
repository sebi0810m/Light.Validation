using Bachelor.Thesis.Benchmarking.ParametersPrimitiveAll;
using LinqToDB;
using LinqToDB.Data;
using Synnotech.Linq2Db;

namespace Bachelor.Thesis.Benchmarking.WebApi.Cases.ParametersPrimitiveAll;

public class LinqToDbAddEmployeeSession : AsyncSession, IAddEmployeeSession
{
    public LinqToDbAddEmployeeSession(DataConnection dataConnection) : base(dataConnection) { }

    public Task<int> InsertEmployeeAsync(EmployeeDto employee)
    {
        return DataConnection.InsertWithInt32IdentityAsync(employee);
    }
}