using Bachelor.Thesis.Benchmarking.ParametersPrimitiveTwo;
using Bachelor.Thesis.Benchmarking.ParametersPrimitiveTwo.Validators;
using Bachelor.Thesis.Benchmarking.WebApi.Validation;
using Raven.Client.Documents;
using Synnotech.AspNetCore.MinimalApis.Responses;

namespace Bachelor.Thesis.Benchmarking.WebApi.Repository;

public class ParametersPrimitiveTwoRepo : IRepository<UserDto>
{
    public static string Url = "/api/primitive/two/";

    private readonly IDocumentStore _store;

    public ParametersPrimitiveTwoRepo()
    {
        _store = RavenDbConnector.SetupRavenDbConnection();
    }

    public IResult CreateWithFluentValidation(UserDto value)
    {
        var errors = new FluentValidator<UserDto>(new FluentValidator(), value).PerformValidation();
        if (!errors.IsValid)
            return Response.ValidationProblem(ParseValidationResultsToCorrectType.ParseFluentValidationResults(errors));

        value.StoreNewUserDtoInDatabase(_store);

        return Response.Created($"{Url}{value.Id}", value);
    }

    public IResult CreateWithLightValidation(UserDto value)
    {
        var errors = new LightValidator<UserDto>(new LightValidator(), value).PerformValidation();

        if (!errors.IsValid)
            return Response.ValidationProblem(ParseValidationResultsToCorrectType.ParseLightValidationResults(errors));

        value.StoreNewUserDtoInDatabase(_store);

        return Response.Created($"{Url}{value.Id}", value);
    }

    public IResult CreateWithModelValidation(UserDto value)
    {
        var errors = new ModelValidator<UserDto>(value).PerformValidation();

        if (errors.Count != 0)
            return Response.ValidationProblem(ParseValidationResultsToCorrectType.ParseModelValidationResults(errors));

        value.StoreNewUserDtoInDatabase(_store);

        return Response.Created($"{Url}{value.Id}", value);
    }
}