using Bachelor.Thesis.Benchmarking.ParametersPrimitiveTwo;
using Bachelor.Thesis.Benchmarking.ParametersPrimitiveTwo.Validators;
using Bachelor.Thesis.Benchmarking.WebApi.Validation;

namespace Bachelor.Thesis.Benchmarking.WebApi.Repository;

public class ParametersPrimitiveTwoRepo : IRepository<UserDto>
{
    private readonly Dictionary<Guid, UserDto> _users = new ();

    public UserDto CreateWithFluentValidation(UserDto value)
    {
        new FluentValidator<UserDto>(new FluentValidator(), value).PerformValidation();

        _users.Add(Guid.NewGuid(), value);

        return value;
    }

    public UserDto CreateWithLightValidation(UserDto value)
    {
        new LightValidator<UserDto>(new LightValidator(), value).PerformValidation();

        _users.Add(Guid.NewGuid(), value);

        return value;
    }

    public UserDto CreateWithModelValidation(UserDto value)
    {
        new ModelValidator<UserDto>(value).PerformValidation();

        _users.Add(Guid.NewGuid(), value);

        return value;
    }
}