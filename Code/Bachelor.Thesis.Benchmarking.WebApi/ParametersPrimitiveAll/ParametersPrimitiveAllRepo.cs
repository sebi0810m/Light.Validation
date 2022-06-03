using Bachelor.Thesis.Benchmarking.ParametersPrimitiveAll;
using Bachelor.Thesis.Benchmarking.WebApi.Repository;
using Synnotech.DatabaseAbstractions;

namespace Bachelor.Thesis.Benchmarking.WebApi.ParametersPrimitiveAll;

public class ParametersPrimitiveAllRepo : IRepository<EmployeeDto, IAddEmployeeSession, IGetEmployeeSession>
{
    public const string Url = "/api/primitive/all/";
    public Task<IResult> CreateWithFluentValidationAsync(EmployeeDto value, ISessionFactory<IAddEmployeeSession> sessionFactory)
    {
        throw new NotImplementedException();
    }

    public Task<IResult> CreateWithLightValidationAsync(EmployeeDto value, ISessionFactory<IAddEmployeeSession> sessionFactory)
    {
        throw new NotImplementedException();
    }

    public Task<IResult> CreateWithModelValidationAsync(EmployeeDto value, ISessionFactory<IAddEmployeeSession> sessionFactory)
    {
        throw new NotImplementedException();
    }

    public Task<IResult> GetObjectByIdAsync(int id, ISessionFactory<IGetEmployeeSession> sessionFactory)
    {
        throw new NotImplementedException();
    }
}