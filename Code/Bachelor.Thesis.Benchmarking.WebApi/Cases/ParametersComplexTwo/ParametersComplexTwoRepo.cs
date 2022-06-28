using Bachelor.Thesis.Benchmarking.ParametersComplexTwo.Dto;
using Bachelor.Thesis.Benchmarking.ParametersComplexTwo.FluentValidator;
using Bachelor.Thesis.Benchmarking.ParametersComplexTwo.LightValidator;
using Bachelor.Thesis.Benchmarking.WebApi.Repository;
using Bachelor.Thesis.Benchmarking.WebApi.Validation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using Synnotech.AspNetCore.MinimalApis.Responses;
using Synnotech.DatabaseAbstractions;

namespace Bachelor.Thesis.Benchmarking.WebApi.Cases.ParametersComplexTwo;

public class ParametersComplexTwoRepo 
    : IRepository<CustomerDto, int, LightDtoValidator, FluentDtoValidator, IAddCustomerSession, IGetCustomerSession>
{
    public const string Url = "/api/complex/two/";

    public async Task<IResult> CreateWithLightValidationAsync(
        CustomerDto value,
        LightDtoValidator validator,
        ISessionFactory<IAddCustomerSession> sessionFactory)
    {
        if (validator.CheckForErrors(value, out var errors))
            return Response.BadRequest(errors);

        value = await InsertEmployeeIntoDatabase(value, sessionFactory);

        return Response.Created($"{Url}{value.Guid}", value);
    }

    public async Task<IResult> CreateWithFluentValidationAsync(
        CustomerDto value,
        FluentDtoValidator validator,
        ISessionFactory<IAddCustomerSession> sessionFactory)
    {
        // ReSharper disable once MethodHasAsyncOverload
        var errors = validator.Validate(value);

        if (!errors.IsValid)
        {
            var modelStateDictionary = new ModelStateDictionary();
            errors.AddToModelState(modelStateDictionary, string.Empty);
            return Response.BadRequest(modelStateDictionary);
        }

        value = await InsertEmployeeIntoDatabase(value, sessionFactory);

        return Response.Created($"{Url}{value.Guid}", value);
    }

    public async Task<IResult> CreateWithModelValidationAsync(
        CustomerDto value,
        ISessionFactory<IAddCustomerSession> sessionFactory)
    {
        var errors = ModelValidator.PerformValidation(value);
        
        if (errors.Count != 0)
            return Response.BadRequest(errors);

        value = await InsertEmployeeIntoDatabase(value, sessionFactory);

        return Response.Created($"{Url}{value.Guid}", value);
    }

    public async Task<IResult> GetObjectByIdAsync(
        int id,
        ISessionFactory<IGetCustomerSession> sessionFactory)
    {
        await using var session = await sessionFactory.OpenSessionAsync();

        var value = await session.GetCustomerByIdAsync(id);

        if (value == null)
            return Response.NotFound();

        return Response.Ok(DeserializeCustomerDto(value));
    }

    private static async Task<CustomerDto> InsertEmployeeIntoDatabase(
        CustomerDto value, 
        ISessionFactory<IAddCustomerSession> sessionFactory)
    {
        await using var session = await sessionFactory.OpenSessionAsync();

        value.Id = await session.InsertCustomerAsync(value);
        await session.SaveChangesAsync();

        return value;
    }

    private static CustomerDto DeserializeCustomerDto(CustomerEntity value) =>
        new ()
        {
            Guid = value.CustomerId,
            User = JsonConvert.DeserializeObject<User>(value.User),
            Address = JsonConvert.DeserializeObject<Address>(value.Address)
        };
}