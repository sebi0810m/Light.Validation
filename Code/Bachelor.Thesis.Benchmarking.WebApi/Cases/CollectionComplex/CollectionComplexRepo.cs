using Bachelor.Thesis.Benchmarking.CollectionComplex.Dto;
using Bachelor.Thesis.Benchmarking.CollectionComplex.FluentValidation;
using Bachelor.Thesis.Benchmarking.CollectionComplex.LightValidation;
using Bachelor.Thesis.Benchmarking.WebApi.Repository;
using Bachelor.Thesis.Benchmarking.WebApi.Validation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using Synnotech.AspNetCore.MinimalApis.Responses;
using Synnotech.DatabaseAbstractions;

namespace Bachelor.Thesis.Benchmarking.WebApi.Cases.CollectionComplex;

public class CollectionComplexRepo
    : IRepository<CollectionComplexDto, int, LightDtoValidator, FluentDtoValidator, IAddCollectionComplexSession, IGetCollectionComplexSession>
{
    public const string Url = "/api/collection/complex/";

    public async Task<IResult> CreateWithLightValidationAsync(
        CollectionComplexDto value,
        LightDtoValidator validator,
        ISessionFactory<IAddCollectionComplexSession> sessionFactory)
    {
        if (validator.CheckForErrors(value, out var errors))
            return Response.BadRequest(errors);

        value = await InsertCollectionComplexIntoDatabase(value, sessionFactory);

        return Response.Created($"{Url}{value.Id}", value);
    }

    public async Task<IResult> CreateWithFluentValidationAsync(
        CollectionComplexDto value,
        FluentDtoValidator validator,
        ISessionFactory<IAddCollectionComplexSession> sessionFactory)
    {
        // ReSharper disable once MethodHasAsyncOverload
        var errors = validator.Validate(value);

        if (!errors.IsValid)
        {
            var modelStateDictionary = new ModelStateDictionary();
            errors.AddToModelState(modelStateDictionary, string.Empty);
            return Response.BadRequest(errors);
        }

        value = await InsertCollectionComplexIntoDatabase(value, sessionFactory);

        return Response.Created($"{Url}{value.Id}", value);
    }

    public async Task<IResult> CreateWithModelValidationAsync(
        CollectionComplexDto value,
        ISessionFactory<IAddCollectionComplexSession> sessionFactory)
    {
        var errors = ModelValidatorHelper.PerformValidation(value);

        if (errors.Count != 0)
            return Response.BadRequest(errors.ToModelStateDictionary());

        value = await InsertCollectionComplexIntoDatabase(value, sessionFactory);

        return Response.Created($"{Url}{value.Id}", value);
    }

    public async Task<IResult> GetObjectByIdAsync(
        int id,
        ISessionFactory<IGetCollectionComplexSession> sessionFactory)
    {
        await using var session = await sessionFactory.OpenSessionAsync();

        var value = await session.GetCollectionComplexByIdAsync(id);

        if (value == null)
            return Response.NotFound();

        return Response.Ok(DeserializeCollectionComplexDto(value));
    }

    private static async Task<CollectionComplexDto> InsertCollectionComplexIntoDatabase(
        CollectionComplexDto value,
        ISessionFactory<IAddCollectionComplexSession> sessionFactory)
    {
        await using var session = await sessionFactory.OpenSessionAsync();

        value.Id = await session.InsertCollectionComplexAsync(value);
        await session.SaveChangesAsync();

        return value;
    }

    private static CollectionComplexDto DeserializeCollectionComplexDto(CollectionComplexEntity value) =>
        new ()
        {
            Id = value.Id,
            Guid = value.Guid,
            OrderDetailsList = JsonConvert.DeserializeObject<List<OrderDetails>>(value.OrderDetailsList),
            ArticleList = JsonConvert.DeserializeObject<List<Article>>(value.ArticleList)
        };
}