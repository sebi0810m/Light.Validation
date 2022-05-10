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

        app.MapPost("/api/primitive/two/light", ([FromServices] ParametersPrimitiveTwoRepo repo, UserDto user) =>
        {
            try
            {
                var createdUser = repo.CreateWithLightValidation(user);
                return Results.Created($"/api/primitive/two/{user.Id}", user);
            }
            catch (Exception ex)
            {
                return Results.ValidationProblem()
            }
        });

        app.Run();
    }
}