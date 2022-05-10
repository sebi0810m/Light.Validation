using Bachelor.Thesis.Benchmarking.ParametersPrimitiveTwo;
using Bachelor.Thesis.Benchmarking.WebApi.Repository;
using Microsoft.AspNetCore.Mvc;

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

        app.MapPost("/api/primitive/two/light", ([FromServices] ParametersPrimitiveTwoRepo repo, UserDto user) => repo.CreateWithFluentValidation(user));
        app.MapPost("/api/primitive/two/light", ([FromServices] ParametersPrimitiveTwoRepo repo, UserDto user) => repo.CreateWithFluentValidation(user));
        app.MapPost("/api/primitive/two/light", ([FromServices] ParametersPrimitiveTwoRepo repo, UserDto user) => repo.CreateWithFluentValidation(user));

        app.Run();
    }
}