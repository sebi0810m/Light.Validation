using Bachelor.Thesis.Benchmarking.ParametersPrimitiveTwo;
using Bachelor.Thesis.Benchmarking.ParametersPrimitiveTwo.Validators;
using Bachelor.Thesis.Benchmarking.WebApi.Database;
using Bachelor.Thesis.Benchmarking.WebApi.Validation;
using Microsoft.AspNetCore.Mvc;
using Synnotech.AspNetCore.MinimalApis.Responses;
using Synnotech.DatabaseAbstractions;

namespace Bachelor.Thesis.Benchmarking.WebApi.Repository;

public class ParametersPrimitiveTwoRepo
{
    public static string Url = "/api/primitive/two/";

    public IResult CreateWithLightValidation(UserDto value)
    {
        var errors = new LightValidator<UserDto>(new LightValidator(), value).PerformValidation();

        if (!errors.IsValid)
            return Response.ValidationProblem(ParseValidationResultsToCorrectType.ParseLightValidationResults(errors));

        return Response.Created($"{Url}{value.Id}", value);
    }

    public IResult CreateWithModelValidation(UserDto value)
    {
        var errors = new ModelValidator<UserDto>(value).PerformValidation();

        if (errors.Count != 0)
            return Response.ValidationProblem(ParseValidationResultsToCorrectType.ParseModelValidationResults(errors));

        return Response.Created($"{Url}{value.Id}", value);
    }

    public async Task<IResult> CreateWithFluentValidation(
        UserDto value,
        ISessionFactory<IAddUserSession> sessionFactory)
    {
        var errors = new FluentValidator<UserDto>(new FluentValidator(), value).PerformValidation();
        if (!errors.IsValid)
            return Response.ValidationProblem(ParseValidationResultsToCorrectType.ParseFluentValidationResults(errors));

        await using var session = await sessionFactory.OpenSessionAsync();
        value.Id = await session.InsertUserAsync(value); // TODO: System.Data.SqlClient.SqlException (0x80131904): Invalid object name 'ParametersPrimitiveTwo'.
        await session.SaveChangesAsync();

        return Response.Created($"{Url}{value.Id}", value);
    }
}