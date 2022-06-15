using Bachelor.Thesis.Benchmarking.CollectionFlat;
using Bachelor.Thesis.Benchmarking.CollectionFlat.Validators;
using Bachelor.Thesis.Benchmarking.WebApi.Repository;
using Bachelor.Thesis.Benchmarking.WebApi.Validation;
using Newtonsoft.Json;
using Synnotech.AspNetCore.MinimalApis.Responses;
using Synnotech.DatabaseAbstractions;

namespace Bachelor.Thesis.Benchmarking.WebApi.Cases.CollectionFlat;

public class CollectionFlatRepo : IRepository<CollectionFlatDto, Guid, IAddCollectionFlatSession, IGetCollectionFlatSession>
{
    public const string Url = "/api/collection/flat/";

    public async Task<IResult> CreateWithLightValidationAsync(
        CollectionFlatDto value,
        ISessionFactory<IAddCollectionFlatSession> sessionFactory)
    {
        var errors = new LightValidator<CollectionFlatDto>(new LightDtoValidator(), value).PerformValidation();

        if (!errors.IsValid)
            return Response.ValidationProblem(ParseValidationResultsToCorrectType.ParseLightValidationResults(errors));

        value = await InsertCollectionFlatIntoDatabase(value, sessionFactory);

        return Response.Created($"{Url}{value.Id}", value);
    }

    public async Task<IResult> CreateWithFluentValidationAsync(
        CollectionFlatDto value,
        ISessionFactory<IAddCollectionFlatSession> sessionFactory)
    {
        var errors = new FluentValidator<CollectionFlatDto>(new FluentDtoValidator(), value).PerformValidation();

        if (!errors.IsValid)
            return Response.ValidationProblem(ParseValidationResultsToCorrectType.ParseFluentValidationResults(errors));

        value = await InsertCollectionFlatIntoDatabase(value, sessionFactory);

        return Response.Created($"{Url}{value.Id}", value);
    }

    public async Task<IResult> CreateWithModelValidationAsync(
        CollectionFlatDto value,
        ISessionFactory<IAddCollectionFlatSession> sessionFactory)
    {
        var errors = new ModelValidator<CollectionFlatDto>(value).PerformValidation();

        if (errors.Count != 0)
            return Response.ValidationProblem(ParseValidationResultsToCorrectType.ParseModelValidationResults(errors));

        value = await InsertCollectionFlatIntoDatabase(value, sessionFactory);

        return Response.Created($"{Url}{value.Id}", value);
    }

    public async Task<IResult> GetObjectByIdAsync(
        Guid id,
        ISessionFactory<IGetCollectionFlatSession> sessionFactory)
    {
        await using var session = await sessionFactory.OpenSessionAsync();

        var value = await session.GetCollectionFlatAsync(id);

        if (value == null)
            return Response.NotFound();

        return Response.Ok(DeserializeCollectionFlatDto(value));
    }

    private static async Task<CollectionFlatDto> InsertCollectionFlatIntoDatabase(
        CollectionFlatDto value,
        ISessionFactory<IAddCollectionFlatSession> sessionFactory)
    {
        await using var session = await sessionFactory.OpenSessionAsync();

        value.Id = (Guid) await session.InsertCollectionFlatAsync(value);
        await session.SaveChangesAsync();

        return value;
    }

    private static CollectionFlatDto DeserializeCollectionFlatDto(SerializedCollectionFlat value) =>
        new ()
        {
            Id = value.Id,
            Names = JsonConvert.DeserializeObject<List<string>>(value.Names),
            Availability = JsonConvert.DeserializeObject<Dictionary<long, bool>>(value.Availability)
        };
}