namespace Bachelor.Thesis.Benchmarking.WebApi.Cases.ParametersComplexTwo;

public class SerializedCustomerDto
{
    public Guid CustomerId { get; set; }

    public string User { get; set; } = string.Empty;

    public string Address { get; set; } = string.Empty;
}