using Bachelor.Thesis.Benchmarking.ParametersComplexTwo.Dto;
using Bachelor.Thesis.Benchmarking.ParametersComplexTwo.FluentValidator;
using Bachelor.Thesis.Benchmarking.ParametersComplexTwo.LightValidator;
using Bachelor.Thesis.Benchmarking.WebApi.Repository;
using Bachelor.Thesis.Benchmarking.WebApi.Validation;
using Newtonsoft.Json;
using Synnotech.AspNetCore.MinimalApis.Responses;
using Synnotech.DatabaseAbstractions;

namespace Bachelor.Thesis.Benchmarking.WebApi.Cases.ParametersComplexTwo;

public class ParametersComplexTwoRepo : IRepository<CustomerDto, Guid, IAddCustomerSession, IGetCustomerSession>
{
    public const string Url = "/api/complex/two/";

    public async Task<IResult> CreateWithLightValidationAsync(
        CustomerDto value,
        ISessionFactory<IAddCustomerSession> sessionFactory)
    {
        var errors = new LightValidator<CustomerDto>(new LightDtoValidator(), value).PerformValidation();

        if (!errors.IsValid)
            return Response.ValidationProblem(ParseValidationResultsToCorrectType.ParseLightValidationResults(errors));

        value = await InsertEmployeeIntoDatabase(value, sessionFactory);

        return Response.Created($"{Url}{value.CustomerId}", value);
    }

    public async Task<IResult> CreateWithFluentValidationAsync(
        CustomerDto value,
        ISessionFactory<IAddCustomerSession> sessionFactory)
    {
        var errors = new FluentValidator<CustomerDto>(new FluentDtoValidator(), value).PerformValidation();

        if (!errors.IsValid)
            return Response.ValidationProblem(ParseValidationResultsToCorrectType.ParseFluentValidationResults(errors));

        value = await InsertEmployeeIntoDatabase(value, sessionFactory);

        return Response.Created($"{Url}{value.CustomerId}", value);
    }

    public async Task<IResult> CreateWithModelValidationAsync(
        CustomerDto value,
        ISessionFactory<IAddCustomerSession> sessionFactory)
    {
        var errors = new ModelValidator<CustomerDto>(value).PerformValidation();

        if (errors.Count != 0)
            return Response.ValidationProblem(ParseValidationResultsToCorrectType.ParseModelValidationResults(errors));

        value = await InsertEmployeeIntoDatabase(value, sessionFactory);

        return Response.Created($"{Url}{value.CustomerId}", value);
    }

    public async Task<IResult> GetObjectByIdAsync(
        Guid id,
        ISessionFactory<IGetCustomerSession> sessionFactory)
    {
        await using var session = await sessionFactory.OpenSessionAsync();

        var value = await session.GetCustomerByIdAsync(id);

        if (value == null)
            return Response.NotFound();

        return Response.Ok(DeserializeCustomerDto(value));
    }

    private static async Task<CustomerDto> InsertEmployeeIntoDatabase(CustomerDto value, ISessionFactory<IAddCustomerSession> sessionFactory)
    {
        await using var session = await sessionFactory.OpenSessionAsync();

        value.CustomerId = (Guid) await session.InsertCustomerAsync(value);
        await session.SaveChangesAsync();

        return value;
    }

    private static CustomerDto DeserializeCustomerDto(SerializedCustomerDto value) =>
        new ()
        {
            CustomerId = value.CustomerId,
            User = JsonConvert.DeserializeObject<User>(value.User),
            Address = JsonConvert.DeserializeObject<Address>(value.Address)
        };
}