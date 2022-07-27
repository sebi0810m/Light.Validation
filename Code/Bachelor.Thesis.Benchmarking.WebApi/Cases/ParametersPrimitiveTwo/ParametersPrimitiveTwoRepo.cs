using Bachelor.Thesis.Benchmarking.ParametersPrimitiveTwo;
using Bachelor.Thesis.Benchmarking.ParametersPrimitiveTwo.Validators;
using Bachelor.Thesis.Benchmarking.WebApi.Repository;
using Bachelor.Thesis.Benchmarking.WebApi.Validation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Synnotech.AspNetCore.MinimalApis.Responses;
using Synnotech.DatabaseAbstractions;

namespace Bachelor.Thesis.Benchmarking.WebApi.Cases.ParametersPrimitiveTwo;

public class ParametersPrimitiveTwoRepo
    : IRepository<UserDto, int, LightValidator, FluentValidator, IAddUserSession, IGetUserSession>
{
    public const string Url = "/api/primitive/two/";

    public async Task<IResult> CreateWithLightValidationAsync(
        UserDto value,
        LightValidator validator,
        ISessionFactory<IAddUserSession> sessionFactory)
    {
        if (validator.CheckForErrors(value, out var errors))
            return Response.BadRequest(errors);

        value = await InsertUserIntoDatabase(value, sessionFactory);

        return Response.Created($"{Url}{value.Id}", value);
    }

    public async Task<IResult> CreateWithFluentValidationAsync(
        UserDto value,
        FluentValidator validator,
        ISessionFactory<IAddUserSession> sessionFactory)
    {
        // ReSharper disable once MethodHasAsyncOverload -- we do not call third-party services during validation, thus no async
        var errors = validator.Validate(value);
        if (!errors.IsValid)
            return Response.BadRequest(errors.ToModelStateDictionary());

        value = await InsertUserIntoDatabase(value, sessionFactory);

        return Response.Created($"{Url}{value.Id}", value);
    }

    public async Task<IResult> CreateWithModelValidationAsync(
        UserDto value,
        ISessionFactory<IAddUserSession> sessionFactory)
    {
        var errors = ModelValidatorHelper.PerformValidation(value);

        if (errors.Count != 0)
            return Response.BadRequest(errors.ToModelStateDictionary());

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

    private static async Task<UserDto> InsertUserIntoDatabase(UserDto value, ISessionFactory<IAddUserSession> sessionFactory)
    {
        await using var session = await sessionFactory.OpenSessionAsync();
        value.Id = await session.InsertUserAsync(value);
        await session.SaveChangesAsync();
        return value;
    }
}