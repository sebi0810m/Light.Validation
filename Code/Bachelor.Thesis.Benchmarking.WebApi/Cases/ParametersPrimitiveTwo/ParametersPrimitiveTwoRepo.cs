using Bachelor.Thesis.Benchmarking.ParametersPrimitiveTwo;
using Bachelor.Thesis.Benchmarking.ParametersPrimitiveTwo.Validators;
using Bachelor.Thesis.Benchmarking.WebApi.Repository;
using Bachelor.Thesis.Benchmarking.WebApi.Validation;
using Synnotech.AspNetCore.MinimalApis.Responses;
using Synnotech.DatabaseAbstractions;

namespace Bachelor.Thesis.Benchmarking.WebApi.Cases.ParametersPrimitiveTwo;

public class ParametersPrimitiveTwoRepo : IRepository<UserDto, int, IAddUserSession, IGetUserSession>
{
    public const string Url = "/api/primitive/two/";

    public async Task<IResult> CreateWithLightValidationAsync(
        UserDto value,
        ISessionFactory<IAddUserSession> sessionFactory)
    {
        var errors = new LightValidator<UserDto>(new LightValidator(), value).PerformValidation();

        if (!errors.IsValid)
            return Response.ValidationProblem(ParseValidationResultsToCorrectType.ParseLightValidationResults(errors));

        value = await InsertUserIntoDatabase(value, sessionFactory);

        return Response.Created($"{Url}{value.Id}", value);
    }

    public async Task<IResult> CreateWithFluentValidationAsync(
        UserDto value,
        ISessionFactory<IAddUserSession> sessionFactory)
    {
        var errors = new FluentValidator<UserDto>(new FluentValidator(), value).PerformValidation();
        if (!errors.IsValid)
            return Response.ValidationProblem(ParseValidationResultsToCorrectType.ParseFluentValidationResults(errors));

        value = await InsertUserIntoDatabase(value, sessionFactory);

        return Response.Created($"{Url}{value.Id}", value);
    }

    public async Task<IResult> CreateWithModelValidationAsync(
        UserDto value,
        ISessionFactory<IAddUserSession> sessionFactory)
    {
        var errors = new ModelValidator<UserDto>(value).PerformValidation();

        if (errors.Count != 0)
            return Response.ValidationProblem(ParseValidationResultsToCorrectType.ParseModelValidationResults(errors));

        value = await InsertUserIntoDatabase(value, sessionFactory);

        return Response.Created($"{Url}{value.Id}", value);
    }

    public async Task<IResult> GetObjectByIdAsync(
        int userId,
        ISessionFactory<IGetUserSession> sessionFactory)
    {
        await using var session = await sessionFactory.OpenSessionAsync();

        var value = await session.GetUserByIdAsync(userId);

        if (value == null)
            return Response.NotFound();

        return Response.Ok(value);
    }

    private async Task<UserDto> InsertUserIntoDatabase(UserDto value, ISessionFactory<IAddUserSession> sessionFactory)
    {
        await using var session = await sessionFactory.OpenSessionAsync();
        value.Id = await session.InsertUserAsync(value);
        await session.SaveChangesAsync();
        return value;
    }
}