using Bachelor.Thesis.Benchmarking.ParametersPrimitiveTwo;
using LinqToDB;
using LinqToDB.Data;
using Synnotech.Linq2Db;

namespace Bachelor.Thesis.Benchmarking.WebApi.Cases.ParametersPrimitiveTwo;

public class LinqToDbGetUserSession : AsyncReadOnlySession, IGetUserSession
{
    public LinqToDbGetUserSession(DataConnection dataConnection) : base(dataConnection) { }

    public Task<UserDto?> GetUserByIdAsync(int userId) =>
        DataConnection.GetTable<UserDto>()
                      .FirstOrDefaultAsync(user => user.Id == userId);
}