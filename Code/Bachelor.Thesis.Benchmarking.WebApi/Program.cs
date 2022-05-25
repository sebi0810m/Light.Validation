using Bachelor.Thesis.Benchmarking.WebApi.Database;
using Bachelor.Thesis.Benchmarking.WebApi.Repository;
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
               .AddSingleton<ParametersPrimitiveTwoRepo>()
               .AddLinq2DbForSqlServer(Mappings.CreateMappings, SqlServerProvider.SystemDataSqlClient)
               .AddServicesForDtoInsertionIntoDatabase();

        var app = builder.Build();

        app.UseHttpsRedirection();

        app.MapGet("", () => "Hello World");

        app.AddMappingsForDtoInsertionIntoDatabase();

        app.Run();
    }
}