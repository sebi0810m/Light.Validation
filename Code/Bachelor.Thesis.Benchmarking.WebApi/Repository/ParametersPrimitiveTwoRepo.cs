using Bachelor.Thesis.Benchmarking.ParametersPrimitiveTwo;
using Bachelor.Thesis.Benchmarking.ParametersPrimitiveTwo.Validators;
using Bachelor.Thesis.Benchmarking.WebApi.Database;
using Bachelor.Thesis.Benchmarking.WebApi.Validation;
using Synnotech.AspNetCore.MinimalApis.Responses;
using Synnotech.DatabaseAbstractions;

namespace Bachelor.Thesis.Benchmarking.WebApi.Repository;

public class ParametersPrimitiveTwoRepo
{
    public static string Url = "/api/primitive/two/";

    public async Task<IResult> CreateWithLightValidation(
        UserDto value,
        ISessionFactory<IAddUserSession> sessionFactory)
    {
        var errors = new LightValidator<UserDto>(new LightValidator(), value).PerformValidation();

        if (!errors.IsValid)
            return Response.ValidationProblem(ParseValidationResultsToCorrectType.ParseLightValidationResults(errors));

        await InsertUserIntoDatabase(value, sessionFactory);

        return Response.Created($"{Url}{value.Id}", value);
    }

    public async Task<IResult> CreateWithModelValidation(
        UserDto value,
        ISessionFactory<IAddUserSession> sessionFactory)
    {
        var errors = new ModelValidator<UserDto>(value).PerformValidation();

        if (errors.Count != 0)
            return Response.ValidationProblem(ParseValidationResultsToCorrectType.ParseModelValidationResults(errors));

        await InsertUserIntoDatabase(value, sessionFactory);

        return Response.Created($"{Url}{value.Id}", value);
    }

    public async Task<IResult> CreateWithFluentValidation(
        UserDto value,
        ISessionFactory<IAddUserSession> sessionFactory)
    {
        // TODO: ID is already included in request value => needed for validator, but is replaced in database call
        var errors = new FluentValidator<UserDto>(new FluentValidator(), value).PerformValidation();
        if (!errors.IsValid)
            return Response.ValidationProblem(ParseValidationResultsToCorrectType.ParseFluentValidationResults(errors));

        await InsertUserIntoDatabase(value, sessionFactory);

        return Response.Created($"{Url}{value.Id}", value);
    }

    private async Task<UserDto> InsertUserIntoDatabase(UserDto value, ISessionFactory<IAddUserSession> sessionFactory)
    {
        await using var session = await sessionFactory.OpenSessionAsync();
        value.Id = await session.InsertUserAsync(value);
        await session.SaveChangesAsync();
        return value;
    }
}