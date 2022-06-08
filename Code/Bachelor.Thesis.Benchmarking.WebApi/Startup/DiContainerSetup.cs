using Bachelor.Thesis.Benchmarking.WebApi.ParametersComplexTwo;
using Bachelor.Thesis.Benchmarking.WebApi.ParametersPrimitiveAll;
using Bachelor.Thesis.Benchmarking.WebApi.ParametersPrimitiveTwo;

namespace Bachelor.Thesis.Benchmarking.WebApi.Startup;

public static class DiContainerSetup
{
    public static IServiceCollection AddServicesForDtoInsertionIntoDatabase(this IServiceCollection services)
    {
        return services.AddUserDtoServices()
                       .AddEmployeeDtoServices()
                       .AddCustomerDtoServices();
    }
}