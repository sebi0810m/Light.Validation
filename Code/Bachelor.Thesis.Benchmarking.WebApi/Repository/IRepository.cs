using Synnotech.DatabaseAbstractions;

namespace Bachelor.Thesis.Benchmarking.WebApi.Repository;

public interface IRepository<in T, in TId, TInsertObjectSession, TGetObjectSession>
{
    Task<IResult> CreateWithLightValidationAsync(T value, ISessionFactory<TInsertObjectSession> sessionFactory);

    Task<IResult> CreateWithFluentValidationAsync(T value, ISessionFactory<TInsertObjectSession> sessionFactory);

    Task<IResult> CreateWithModelValidationAsync(T value, ISessionFactory<TInsertObjectSession> sessionFactory);

    Task<IResult> GetObjectByIdAsync(TId id, ISessionFactory<TGetObjectSession> sessionFactory);
}