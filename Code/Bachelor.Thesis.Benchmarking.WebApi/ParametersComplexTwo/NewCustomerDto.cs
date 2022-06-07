namespace Bachelor.Thesis.Benchmarking.WebApi.ParametersComplexTwo;

public class NewCustomerDto
{
    public Guid CustomerId { get; set; }

    public string User { get; set; } = string.Empty;

    public string Address { get; set; } = string.Empty;
}