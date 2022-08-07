using Bachelor.Thesis.Benchmarking.WebApi.Database;
using Bachelor.Thesis.Benchmarking.WebApi.Startup;
using LinqToDB.DataProvider.SqlServer;
using Synnotech.Linq2Db.MsSqlServer;

namespace Bachelor.Thesis.Benchmarking.WebApi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services
               .AddLinq2DbForSqlServer(Mappings.AddMappingsForEntities, SqlServerProvider.SystemDataSqlClient)
               .AddServicesForDtoInsertionIntoDatabase();

        var app = builder.Build();

        app.UseHttpsRedirection();

        app.AddMappingsForDtoInsertionIntoDatabase();

        app.MapGet("/", () => "Hello World! 12:40 Uhr");

        app.Run();
    }
}