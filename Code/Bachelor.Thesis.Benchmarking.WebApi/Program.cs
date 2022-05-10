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

        app.MapPost($"{ParametersPrimitiveTwoRepo.Url}light", ([FromServices] ParametersPrimitiveTwoRepo repo, UserDto user) => repo.CreateWithLightValidation(user));
        app.MapPost($"{ParametersPrimitiveTwoRepo.Url}fluent", ([FromServices] ParametersPrimitiveTwoRepo repo, UserDto user) => repo.CreateWithFluentValidation(user));
        app.MapPost($"{ParametersPrimitiveTwoRepo.Url}model", ([FromServices] ParametersPrimitiveTwoRepo repo, UserDto user) => repo.CreateWithModelValidation(user));

        app.Run();
    }
}