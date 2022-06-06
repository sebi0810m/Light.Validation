using Bachelor.Thesis.Benchmarking.WebApi.ParametersPrimitiveAll;
using Bachelor.Thesis.Benchmarking.WebApi.ParametersPrimitiveTwo;

namespace Bachelor.Thesis.Benchmarking.WebApi.Startup;

public static class MappingSetup
{
    public static WebApplication AddMappingsForDtoInsertionIntoDatabase(this WebApplication app)
    {
        return app.MapUserDtoEndpoints()
                  .AddEmployeeDtoEndpoints();
    }
}