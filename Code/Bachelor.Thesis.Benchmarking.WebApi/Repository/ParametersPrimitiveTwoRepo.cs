using Bachelor.Thesis.Benchmarking.ParametersPrimitiveTwo;
using Bachelor.Thesis.Benchmarking.ParametersPrimitiveTwo.Validators;
using Bachelor.Thesis.Benchmarking.WebApi.Validation;
using Microsoft.AspNetCore.Mvc;
using Synnotech.AspNetCore.MinimalApis.Responses;

namespace Bachelor.Thesis.Benchmarking.WebApi.Repository;

public class ParametersPrimitiveTwoRepo : IRepository<UserDto>
{
    private readonly Dictionary<Guid, UserDto> _users = new ();

    public IResult CreateWithFluentValidation(UserDto value)
    {
        var errors = new FluentValidator<UserDto>(new FluentValidator(), value).PerformValidation();
        if (!errors.IsValid)
        {
            var problem = new ProblemDetails();
            return Response.ValidationProblem(errors);
        }

        _users.Add(Guid.NewGuid(), value);

        return Response.Created($"/{value.Id}", value);
    }

    public IResult CreateWithLightValidation(UserDto value)
    {
        var errors = new LightValidator<UserDto>(new LightValidator(), value).PerformValidation();

        _users.Add(Guid.NewGuid(), value);
        
        return Response.Created($"/{value.Id}", value);
    }

    public IResult CreateWithModelValidation(UserDto value)
    {
        var errors = new ModelValidator<UserDto>(value).PerformValidation();

        _users.Add(Guid.NewGuid(), value);

        return Response.Created($"/{value.Id}", value);
    }
}