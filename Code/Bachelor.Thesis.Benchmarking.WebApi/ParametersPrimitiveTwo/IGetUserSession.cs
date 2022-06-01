using Bachelor.Thesis.Benchmarking.ParametersPrimitiveTwo;
using Synnotech.DatabaseAbstractions;

namespace Bachelor.Thesis.Benchmarking.WebApi.ParametersPrimitiveTwo;

public interface IGetUserSession : IAsyncReadOnlySession
{
    Task<UserDto?> GetUserByIdAsync(int userId);
}