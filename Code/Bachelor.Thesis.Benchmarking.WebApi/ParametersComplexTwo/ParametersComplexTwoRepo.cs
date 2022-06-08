using Bachelor.Thesis.Benchmarking.ParametersComplexTwo.Dto;
using Bachelor.Thesis.Benchmarking.WebApi.Repository;
using Synnotech.DatabaseAbstractions;

namespace Bachelor.Thesis.Benchmarking.WebApi.ParametersComplexTwo;

public class ParametersComplexTwoRepo : IRepository<CustomerDto, Guid, IAddCustomerSession, IGetCustomerSession>
{
    public const string Url = "/api/complex/two/";

    public Task<IResult> CreateWithLightValidationAsync(CustomerDto value, ISessionFactory<IAddCustomerSession> sessionFactory)
    {
        throw new NotImplementedException();
    }

    public Task<IResult> CreateWithFluentValidationAsync(CustomerDto value, ISessionFactory<IAddCustomerSession> sessionFactory)
    {
        throw new NotImplementedException();
    }

    public Task<IResult> CreateWithModelValidationAsync(CustomerDto value, ISessionFactory<IAddCustomerSession> sessionFactory)
    {
        throw new NotImplementedException();
    }

    public Task<IResult> GetObjectByIdAsync(Guid id, ISessionFactory<IGetCustomerSession> sessionFactory)
    {
        throw new NotImplementedException();
    }
}