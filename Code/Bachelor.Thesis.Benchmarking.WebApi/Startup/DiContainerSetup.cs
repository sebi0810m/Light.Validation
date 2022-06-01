using Bachelor.Thesis.Benchmarking.WebApi.ParametersPrimitiveTwo;

namespace Bachelor.Thesis.Benchmarking.WebApi.Startup;

public static class DiContainerSetup
{
    public static IServiceCollection AddServicesForDtoInsertionIntoDatabase(this IServiceCollection services)
    {
        return services.AddInsertUserDto();
    }
}