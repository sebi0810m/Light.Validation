using Bachelor.Thesis.Benchmarking.WebApi.Cases.ParametersComplexTwo;
using Bachelor.Thesis.Benchmarking.WebApi.Cases.ParametersPrimitiveAll;
using Bachelor.Thesis.Benchmarking.WebApi.Cases.ParametersPrimitiveTwo;

namespace Bachelor.Thesis.Benchmarking.WebApi.Startup;

public static class MappingSetup
{
    public static WebApplication AddMappingsForDtoInsertionIntoDatabase(this WebApplication app)
    {
        return app.MapUserDtoEndpoints()
                  .AddEmployeeDtoEndpoints()
                  .AddCustomerDtoEndpoints();
    }
}