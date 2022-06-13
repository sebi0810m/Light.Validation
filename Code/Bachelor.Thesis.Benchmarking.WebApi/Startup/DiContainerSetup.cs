using Bachelor.Thesis.Benchmarking.WebApi.Cases.CollectionFlat;
using Bachelor.Thesis.Benchmarking.WebApi.Cases.ParametersComplexTwo;
using Bachelor.Thesis.Benchmarking.WebApi.Cases.ParametersPrimitiveAll;
using Bachelor.Thesis.Benchmarking.WebApi.Cases.ParametersPrimitiveTwo;

namespace Bachelor.Thesis.Benchmarking.WebApi.Startup;

public static class DiContainerSetup
{
    public static IServiceCollection AddServicesForDtoInsertionIntoDatabase(this IServiceCollection services)
    {
        return services.AddUserDtoServices()
                       .AddEmployeeDtoServices()
                       .AddCustomerDtoServices()
                       .AddCollectionFlatServices();
    }
}