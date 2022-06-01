using Bachelor.Thesis.Benchmarking.WebApi.Controller;

namespace Bachelor.Thesis.Benchmarking.WebApi.Startup;

public static class MappingSetup
{
    public static WebApplication AddMappingsForDtoInsertionIntoDatabase(this WebApplication app)
    {
        return app.MapInsertUserDto();
    }
}