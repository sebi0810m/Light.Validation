using Bachelor.Thesis.Benchmarking.CollectionComplex.Dto;
using Bachelor.Thesis.Benchmarking.CollectionComplex.FluentValidation;
using Bachelor.Thesis.Benchmarking.CollectionComplex.LightValidation;
using Bachelor.Thesis.Benchmarking.WebApi.Repository;
using Bachelor.Thesis.Benchmarking.WebApi.Validation;
using Newtonsoft.Json;
using Synnotech.AspNetCore.MinimalApis.Responses;
using Synnotech.DatabaseAbstractions;

namespace Bachelor.Thesis.Benchmarking.WebApi.Cases.CollectionComplex;

public class CollectionComplexRepo : IRepository<CollectionComplexDto, Guid, IAddCollectionComplexSession, IGetCollectionComplexSession>
{
    public const string Url = "/api/collection/complex/";

    public async Task<IResult> CreateWithLightValidationAsync(CollectionComplexDto value, ISessionFactory<IAddCollectionComplexSession> sessionFactory)
    {
        var errors = new LightValidator<CollectionComplexDto>(new LightDtoValidator(), value).PerformValidation();

        if (!errors.IsValid)
            return Response.ValidationProblem(ParseValidationResultsToCorrectType.ParseLightValidationResults(errors));

        value = await InsertCollectionComplexIntoDatabase(value, sessionFactory);

        return Response.Created($"{Url}{value.Guid}", value);
    }

    public async Task<IResult> CreateWithFluentValidationAsync(CollectionComplexDto value, ISessionFactory<IAddCollectionComplexSession> sessionFactory)
    {
        var errors = new FluentValidator<CollectionComplexDto>(new FluentDtoValidator(), value).PerformValidation();

        if (!errors.IsValid)
            return Response.ValidationProblem(ParseValidationResultsToCorrectType.ParseFluentValidationResults(errors));

        value = await InsertCollectionComplexIntoDatabase(value, sessionFactory);

        return Response.Created($"{Url}{value.Guid}", value);
    }

    public async Task<IResult> CreateWithModelValidationAsync(CollectionComplexDto value, ISessionFactory<IAddCollectionComplexSession> sessionFactory)
    {
        var errors = new ModelValidator<CollectionComplexDto>(value).PerformValidation();

        if (errors.Count != 0)
            return Response.ValidationProblem(ParseValidationResultsToCorrectType.ParseModelValidationResults(errors));

        value = await InsertCollectionComplexIntoDatabase(value, sessionFactory);

        return Response.Created($"{Url}{value.Guid}", value);
    }

    public async Task<IResult> GetObjectByIdAsync(Guid id, ISessionFactory<IGetCollectionComplexSession> sessionFactory)
    {
        await using var session = await sessionFactory.OpenSessionAsync();

        var value = await session.GetCollectionComplexByIdAsync(id);

        if(value == null)
            return Response.NotFound();

        return Response.Ok(DeserializeCollectionComplexDto(value));
    }

    private static async Task<CollectionComplexDto> InsertCollectionComplexIntoDatabase(
        CollectionComplexDto value,
        ISessionFactory<IAddCollectionComplexSession> sessionFactory)
    {
        await using var session = await sessionFactory.OpenSessionAsync();

        value.Guid = (Guid) await session.InsertCollectionComplexAsync(value);
        await session.SaveChangesAsync();

        return value;
    }

    private static CollectionComplexDto DeserializeCollectionComplexDto(CollectionComplexEntity value) =>
        new ()
        {
            Guid = value.Id,
            OrderDetailsList = JsonConvert.DeserializeObject<List<OrderDetails>>(value.OrderDetailsList),
            ArticleList = JsonConvert.DeserializeObject<List<Article>>(value.ArticleList)
        };
}