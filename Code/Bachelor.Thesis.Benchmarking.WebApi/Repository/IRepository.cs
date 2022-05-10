namespace Bachelor.Thesis.Benchmarking.WebApi.Repository;

public interface IRepository<T>
{
    public T CreateWithFluentValidation(T value);

    public T CreateWithLightValidation(T value);

    public T CreateWithModelValidation(T value);
}