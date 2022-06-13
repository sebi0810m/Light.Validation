using Bachelor.Thesis.Benchmarking.ParametersPrimitiveAll;
using Bachelor.Thesis.Benchmarking.ParametersPrimitiveAll.Validators;
using Bachelor.Thesis.Benchmarking.WebApi.Repository;
using Bachelor.Thesis.Benchmarking.WebApi.Validation;
using Synnotech.AspNetCore.MinimalApis.Responses;
using Synnotech.DatabaseAbstractions;

namespace Bachelor.Thesis.Benchmarking.WebApi.Cases.ParametersPrimitiveAll;

public class ParametersPrimitiveAllRepo : IRepository<EmployeeDto, Guid, IAddEmployeeSession, IGetEmployeeSession>
{
    public const string Url = "/api/primitive/all/";

    public async Task<IResult> CreateWithLightValidationAsync(
        EmployeeDto value,
        ISessionFactory<IAddEmployeeSession> sessionFactory)
    {
        var errors = new LightValidator<EmployeeDto>(new LightValidator(), value).PerformValidation();

        if (!errors.IsValid)
            return Response.ValidationProblem(ParseValidationResultsToCorrectType.ParseLightValidationResults(errors));

        value = await InsertEmployeeIntoDatabase(value, sessionFactory);

        return Response.Created($"{Url}{value.Id}", value);
    }

    public async Task<IResult> CreateWithFluentValidationAsync(
        EmployeeDto value,
        ISessionFactory<IAddEmployeeSession> sessionFactory)
    {
        var errors = new FluentValidator<EmployeeDto>(new FluentValidator(), value).PerformValidation();
        if (!errors.IsValid)
            return Response.ValidationProblem(ParseValidationResultsToCorrectType.ParseFluentValidationResults(errors));

        value = await InsertEmployeeIntoDatabase(value, sessionFactory);

        return Response.Created($"{Url}{value.Id}", value);
    }

    public async Task<IResult> CreateWithModelValidationAsync(EmployeeDto value, ISessionFactory<IAddEmployeeSession> sessionFactory)
    {
        var errors = new ModelValidator<EmployeeDto>(value).PerformValidation();

        if (errors.Count != 0)
            return Response.ValidationProblem(ParseValidationResultsToCorrectType.ParseModelValidationResults(errors));

        value = await InsertEmployeeIntoDatabase(value, sessionFactory);

        return Response.Created($"{Url}{value.Id}", value);
    }

    public async Task<IResult> GetObjectByIdAsync(Guid id, ISessionFactory<IGetEmployeeSession> sessionFactory)
    {
        await using var session = await sessionFactory.OpenSessionAsync();

        var value = await session.GetEmployeeByIdAsync(id);

        if(value == null) 
            return Response.NotFound();

        return Response.Ok(value);
    }

    private async Task<EmployeeDto> InsertEmployeeIntoDatabase(EmployeeDto value, ISessionFactory<IAddEmployeeSession> sessionFactory)
    {
        await using var session = await sessionFactory.OpenSessionAsync();

        value.Id = (Guid) await session.InsertEmployeeAsync(value);
        await session.SaveChangesAsync();

        return value;
    }
}