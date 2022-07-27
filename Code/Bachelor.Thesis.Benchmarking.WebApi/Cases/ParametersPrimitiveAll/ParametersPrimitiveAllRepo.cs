using Bachelor.Thesis.Benchmarking.ParametersPrimitiveAll;
using Bachelor.Thesis.Benchmarking.ParametersPrimitiveAll.Validators;
using Bachelor.Thesis.Benchmarking.WebApi.Repository;
using Bachelor.Thesis.Benchmarking.WebApi.Validation;
using Synnotech.AspNetCore.MinimalApis.Responses;
using Synnotech.DatabaseAbstractions;

namespace Bachelor.Thesis.Benchmarking.WebApi.Cases.ParametersPrimitiveAll;

public class ParametersPrimitiveAllRepo
    : IRepository<EmployeeDto, int, LightValidator, FluentValidator, IAddEmployeeSession, IGetEmployeeSession>
{
    public const string Url = "/api/primitive/all/";

    public async Task<IResult> CreateWithLightValidationAsync(
        EmployeeDto value,
        LightValidator validator,
        ISessionFactory<IAddEmployeeSession> sessionFactory)
    {
        if (validator.CheckForErrors(value, out var errors))
            return Response.BadRequest(errors);

        value = await InsertEmployeeIntoDatabase(value, sessionFactory);

        return Response.Created($"{Url}{value.Id}", value);
    }

    public async Task<IResult> CreateWithFluentValidationAsync(
        EmployeeDto value,
        FluentValidator validator,
        ISessionFactory<IAddEmployeeSession> sessionFactory)
    {
        // ReSharper disable once MethodHasAsyncOverload -- we do not call third-party services during validation, thus no async
        var errors = validator.Validate(value);
        if (!errors.IsValid)
            return Response.BadRequest(errors.ToModelStateDictionary());

        value = await InsertEmployeeIntoDatabase(value, sessionFactory);

        return Response.Created($"{Url}{value.Id}", value);
    }

    public async Task<IResult> CreateWithModelValidationAsync(
        EmployeeDto value,
        ISessionFactory<IAddEmployeeSession> sessionFactory)
    {
        var errors = ModelValidatorHelper.PerformValidation(value);
        if (errors.Count != 0)
            return Response.BadRequest(errors.ToModelStateDictionary());

        value = await InsertEmployeeIntoDatabase(value, sessionFactory);

        return Response.Created($"{Url}{value.Id}", value);
    }

    public async Task<IResult> GetObjectByIdAsync(int id, ISessionFactory<IGetEmployeeSession> sessionFactory)
    {
        await using var session = await sessionFactory.OpenSessionAsync();

        var value = await session.GetEmployeeByIdAsync(id);

        if (value == null)
            return Response.NotFound();

        return Response.Ok(value);
    }

    private async Task<EmployeeDto> InsertEmployeeIntoDatabase(EmployeeDto value, ISessionFactory<IAddEmployeeSession> sessionFactory)
    {
        await using var session = await sessionFactory.OpenSessionAsync();

        value.Id = await session.InsertEmployeeAsync(value);
        await session.SaveChangesAsync();

        return value;
    }
}