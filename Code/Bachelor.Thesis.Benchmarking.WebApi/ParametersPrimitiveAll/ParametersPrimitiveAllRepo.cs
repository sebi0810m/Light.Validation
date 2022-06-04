using Bachelor.Thesis.Benchmarking.ParametersPrimitiveAll;
using Bachelor.Thesis.Benchmarking.ParametersPrimitiveAll.Validators;
using Bachelor.Thesis.Benchmarking.WebApi.Repository;
using Bachelor.Thesis.Benchmarking.WebApi.Validation;
using Synnotech.AspNetCore.MinimalApis.Responses;
using Synnotech.DatabaseAbstractions;

namespace Bachelor.Thesis.Benchmarking.WebApi.ParametersPrimitiveAll;

public class ParametersPrimitiveAllRepo : IRepository<EmployeeDto, IAddEmployeeSession, IGetEmployeeSession>
{
    public const string Url = "/api/primitive/all/";

    public async Task<IResult> CreateWithFluentValidationAsync(EmployeeDto value, ISessionFactory<IAddEmployeeSession> sessionFactory)
    {
        var errors = new FluentValidator<EmployeeDto>(new FluentValidator(), value).PerformValidation();
        if (!errors.IsValid)
            return Response.ValidationProblem(ParseValidationResultsToCorrectType.ParseFluentValidationResults(errors));

        value = await InsertEmployeeIntoDatabase(value, sessionFactory);

        return Response.Created($"{Url}{value.Id}", value);
    }

    public Task<IResult> CreateWithLightValidationAsync(EmployeeDto value, ISessionFactory<IAddEmployeeSession> sessionFactory)
    {
        throw new NotImplementedException();
    }

    public Task<IResult> CreateWithModelValidationAsync(EmployeeDto value, ISessionFactory<IAddEmployeeSession> sessionFactory)
    {
        throw new NotImplementedException();
    }

    public Task<IResult> GetObjectByIdAsync(int id, ISessionFactory<IGetEmployeeSession> sessionFactory)
    {
        throw new NotImplementedException();
    }

    private async Task<EmployeeDto> InsertEmployeeIntoDatabase(EmployeeDto value, ISessionFactory<IAddEmployeeSession> sessionFactory)
    {
        await using var session = await sessionFactory.OpenSessionAsync();
        value.Id = await session.InsertEmployeeAsync(value);
        await session.SaveChangesAsync();
        return value;
    }
}