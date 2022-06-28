using Bachelor.Thesis.Benchmarking.CollectionFlat;
using Bachelor.Thesis.Benchmarking.CollectionFlat.Validators;
using Bachelor.Thesis.Benchmarking.WebApi.Repository;
using Bachelor.Thesis.Benchmarking.WebApi.Validation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using Synnotech.AspNetCore.MinimalApis.Responses;
using Synnotech.DatabaseAbstractions;

namespace Bachelor.Thesis.Benchmarking.WebApi.Cases.CollectionFlat;

public class CollectionFlatRepo
    : IRepository<CollectionFlatDto, int, LightDtoValidator, FluentDtoValidator, IAddCollectionFlatSession, IGetCollectionFlatSession>
{
    public const string Url = "/api/collection/flat/";

    public async Task<IResult> CreateWithLightValidationAsync(
        CollectionFlatDto value,
        LightDtoValidator validator,
        ISessionFactory<IAddCollectionFlatSession> sessionFactory)
    {
        if (validator.CheckForErrors(value, out var errors))
            return Response.BadRequest(errors);

        value = await InsertCollectionFlatIntoDatabase(value, sessionFactory);

        return Response.Created($"{Url}{value.Guid}", value);
    }

    public async Task<IResult> CreateWithFluentValidationAsync(
        CollectionFlatDto value,
        FluentDtoValidator validator,
        ISessionFactory<IAddCollectionFlatSession> sessionFactory)
    {
        // ReSharper disable once MethodHasAsyncOverload
        var errors = validator.Validate(value);

        if (!errors.IsValid)
        {
            var modelStateDictionary = new ModelStateDictionary();
            errors.AddToModelState(modelStateDictionary, string.Empty);
            return Response.BadRequest(errors);
        }

        value = await InsertCollectionFlatIntoDatabase(value, sessionFactory);

        return Response.Created($"{Url}{value.Guid}", value);
    }

    public async Task<IResult> CreateWithModelValidationAsync(
        CollectionFlatDto value,
        ISessionFactory<IAddCollectionFlatSession> sessionFactory)
    {
        var errors = ModelValidator.PerformValidation(value);

        if (errors.Count != 0)
            return Response.BadRequest(errors);

        value = await InsertCollectionFlatIntoDatabase(value, sessionFactory);

        return Response.Created($"{Url}{value.Guid}", value);
    }

    public async Task<IResult> GetObjectByIdAsync(
        int id,
        ISessionFactory<IGetCollectionFlatSession> sessionFactory)
    {
        await using var session = await sessionFactory.OpenSessionAsync();

        var value = await session.GetCollectionFlatByIdAsync(id);

        if (value == null)
            return Response.NotFound();

        return Response.Ok(DeserializeCollectionFlatDto(value));
    }

    private static async Task<CollectionFlatDto> InsertCollectionFlatIntoDatabase(
        CollectionFlatDto value,
        ISessionFactory<IAddCollectionFlatSession> sessionFactory)
    {
        await using var session = await sessionFactory.OpenSessionAsync();

        value.Id = await session.InsertCollectionFlatAsync(value);
        await session.SaveChangesAsync();

        return value;
    }

    private static CollectionFlatDto DeserializeCollectionFlatDto(CollectionFlatEntity value) =>
        new ()
        {
            Id = value.Id,
            Guid = value.Guid,
            Names = JsonConvert.DeserializeObject<List<string>>(value.Names),
            Availability = JsonConvert.DeserializeObject<Dictionary<long, bool>>(value.Availability)
        };
}