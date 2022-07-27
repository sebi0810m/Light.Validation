using Bachelor.Thesis.Benchmarking.ParametersPrimitiveTwo;
using Synnotech.DatabaseAbstractions;

namespace Bachelor.Thesis.Benchmarking.WebApi.Cases.ParametersPrimitiveTwo;

public interface IAddUserSession : IAsyncSession
{
    public Task<int> InsertUserAsync(UserDto user);
}