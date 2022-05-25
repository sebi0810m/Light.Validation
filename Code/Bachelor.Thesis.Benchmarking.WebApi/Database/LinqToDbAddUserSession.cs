using Bachelor.Thesis.Benchmarking.ParametersPrimitiveTwo;
using LinqToDB;
using LinqToDB.Data;
using Synnotech.Linq2Db;

namespace Bachelor.Thesis.Benchmarking.WebApi.Database;

public class LinqToDbAddUserSession : AsyncReadOnlySession, IAddUserSession
{
    public LinqToDbAddUserSession(DataConnection dataConnection) : base(dataConnection) { }

    public Task<int> InsertUserAsync(UserDto user)
    {
        return DataConnection.InsertWithInt32IdentityAsync(user);
    }
}