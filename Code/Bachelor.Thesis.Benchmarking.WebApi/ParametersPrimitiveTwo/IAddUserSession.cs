using Bachelor.Thesis.Benchmarking.ParametersPrimitiveTwo;
using Synnotech.DatabaseAbstractions;

namespace Bachelor.Thesis.Benchmarking.WebApi.ParametersPrimitiveTwo;

public interface IAddUserSession : IAsyncSession
{
    public Task<int> InsertUserAsync(UserDto user);
}