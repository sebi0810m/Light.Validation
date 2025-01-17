# Light.Validation
A lightweight library for validating incoming data in .NET HTTP services

[![License](https://img.shields.io/badge/License-MIT-green.svg?style=for-the-badge)](https://github.com/feO2x/Light.Validation/blob/master/LICENSE)
[![NuGet](https://img.shields.io/badge/NuGet-0.5.0-blue.svg?style=for-the-badge)](https://www.nuget.org/packages/Light.Validation/)
[![Documentation](https://img.shields.io/badge/Docs-Wiki-yellowgreen.svg?style=for-the-badge)](https://github.com/feO2x/Light.Validation/wiki)
[![Documentation](https://img.shields.io/badge/Docs-Changelog-yellowgreen.svg?style=for-the-badge)](https://github.com/feO2x/Light.Validation/releases)

## Light.Validation - easy and fast validation for HTTP services

- 👌 easy to start with, can be configured and extended
- 🚀 fast in comparison
- 🔬 imperative API which can be easily debugged if needed
- 👓 supports C# Nullable Reference Types
- ✉️ use the standard error messages or customize / translate them to your liking
- 💠 can be easily integrated in different HTTP frameworks like ASP.NET Core MVC or Minimal APIs

## How to install

Light.Validation is built against .NET 6 and .NET Standard 2.0 and available on [NuGet](https://www.nuget.org/packages/Light.Validation/).

- **Package Reference in csproj**: `<PackageReference Include="Light.Validation" Version="0.5.0" />`
- **dotnet CLI**: `dotnet add package Light.Validation`
- **Visual Studio Package Manager Console**: `Install-Package Light.Validation`

## A simple example

Consider that you are writing an HTTP endpoint where a user can submit a rating for a movie. The incoming data might look like this:

```csharp
public class RateMovieDto
{
    public Guid MovieId { get; set; }
    public int Rating { get; set; }
    public string Comment { get; set; }
}
```

The `MovieId` identifies the target movie, the `Rating` is a value between 0 and 5 and `Comment` is an optional text that the user might add. To validate this DTO, you should create a validator. Please be sure to add using statements for the `Light.Validation` and `Light.Validation.Checks` namespaces.

```csharp
public class RateMovieDtoValidator : Validator<RateMovieDto>
{
    // The passed factory is used to create instances of ValidationContext
    public RateMovieDtoValidator(IValidationContextFactory factory)
        : base(factory) { }

    // By default, a validator will check that the dto is not null
    // before calling this method. Thus in this method, you can
    // simply dereference your DTO without the fear of causing
    // a NullReferenceException.
    protected override RateMovieDto PerformValidation(ValidationContext context,
                                                      RateMovieDto dto)
    {
        // Perform simple checks that add the corresponding default
        // error message to the context if necessary
        context.Check(dto.MovieId).IsNotEmpty();
        context.Check(dto.Rating).IsIn(Range.FromInclusive(0).ToInclusive(5));

        // Light.Validation automatically normalizes strings
        // (null -> empty string, other strings -> trim). We reassign
        // the normalized value to the property here, so that it is
        // available to other code that processes the DTO.
        dto.Comment = context.Check(Comment).IsShorterThan(100);

        // Usually, you want to return the passed DTO, but you can also
        // transform (normalize) the DTO and return another instance
        // if you want to.
        return dto;
    }
}
```

You can then simply inject and use the validator in e.g. an ASP.NET Core MVC controller:

```csharp
[ApiController]
[Route("/api/movies/rate")]
public class RateMovieController : ControllerBase
{
    public RateMoveController(RateMovieDtoValidator validator) =>
         Validator = validator;

    private RateMovieValidator Validator { get; }

    [HttpPost]
    public async Task<IActionResult> RateMovie(RateMovieDto? dto)
    {
        // Validators support C# NRTs, thus the dto variable
        // is considered not null by the C# compiler when
        // CheckForErrors returns false
        if (Validator.CheckForErrors(dto, out object? errors))
            return BadRequest(errors);
            
        // Adding a movie rating to the database is ommitted for brevity's sake
    }
}
```

In a similar way, you can incorporate the validation mechanism in Minimal APIs:

```csharp
app.MapPost("/api/movies/rate", ([FromBody] RateMovieDto? dto,
                                 [FromServices] RateMovieDtoValidator validator)) =>
{
    if (Validator.CheckForErrors(dto, out var errors))
        return Results.BadRequest(errors);
        
    // Adding a movie rating to the database is ommitted for brevity's sake
});
```

The resulting body of the bad request would then look like the following JSON document (in case that all checks found errors):

```json
{
    "movieId": "movieId must not be an empty GUID",
    "rating": "rating must be in range from 0 (inclusive) to 5 (inclusive)",
    "comment": "comment must be shorter than 100"
}
```

To inject your validator, you need to register it with your DI container. Light.Validation is designed to be fast, so by default, your validators can and should be registered as singletons:

```csharp
// The validation context factory only needs to be registered once
services.AddSingleton<IValidationContextFactory>(ValidationContextFactory.Instance) 
        .AddSingleton<RateMovieDtoValidator>();
```