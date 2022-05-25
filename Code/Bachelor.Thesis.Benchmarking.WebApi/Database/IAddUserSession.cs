using Bachelor.Thesis.Benchmarking.ParametersPrimitiveTwo;
using Synnotech.DatabaseAbstractions;

namespace Bachelor.Thesis.Benchmarking.WebApi.Database;

public interface IAddUserSession : IAsyncReadOnlySession
{
    public Task<int> InsertUserAsync(UserDto user);
}