namespace Bachelor.Thesis.Benchmarking.WebApi.Repository;

public interface IRepository<in T>
{
    public IResult CreateWithFluentValidation(T value);

    public IResult CreateWithLightValidation(T value);

    public IResult CreateWithModelValidation(T value);
}