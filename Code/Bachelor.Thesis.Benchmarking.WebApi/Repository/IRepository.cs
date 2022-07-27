using Synnotech.DatabaseAbstractions;

namespace Bachelor.Thesis.Benchmarking.WebApi.Repository;

public interface IRepository<in T, in TId, in TLightValidator, in TFluentValidator, TInsertObjectSession, TGetObjectSession>
{
    Task<IResult> CreateWithLightValidationAsync(T value, TLightValidator validator, ISessionFactory<TInsertObjectSession> sessionFactory);

    Task<IResult> CreateWithFluentValidationAsync(T value, TFluentValidator validator, ISessionFactory<TInsertObjectSession> sessionFactory);

    Task<IResult> CreateWithModelValidationAsync(T value, ISessionFactory<TInsertObjectSession> sessionFactory);

    Task<IResult> GetObjectByIdAsync(TId id, ISessionFactory<TGetObjectSession> sessionFactory);
}