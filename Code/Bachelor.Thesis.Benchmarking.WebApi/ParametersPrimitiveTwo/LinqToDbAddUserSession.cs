using Bachelor.Thesis.Benchmarking.ParametersPrimitiveTwo;
using Bachelor.Thesis.Benchmarking.WebApi.Database;
using LinqToDB;
using LinqToDB.Data;
using Synnotech.Linq2Db;

namespace Bachelor.Thesis.Benchmarking.WebApi.ParametersPrimitiveTwo;

public class LinqToDbAddUserSession : AsyncSession, IAddUserSession
{
    public LinqToDbAddUserSession(DataConnection dataConnection) : base(dataConnection) { }

    public Task<int> InsertUserAsync(UserDto user)
    {
        return DataConnection.InsertWithInt32IdentityAsync(user);
    }
}