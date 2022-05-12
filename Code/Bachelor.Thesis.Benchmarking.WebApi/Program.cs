using Bachelor.Thesis.Benchmarking.WebApi.Repository;

namespace Bachelor.Thesis.Benchmarking.WebApi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddSingleton<ParametersPrimitiveTwoRepo>();

        var app = builder.Build();

        app.UseHttpsRedirection();

        app.MapGet("", () => "Hello World");

        app.AddRoutingForParametersPrimitiveTwo();

        app.Run();
    }
}