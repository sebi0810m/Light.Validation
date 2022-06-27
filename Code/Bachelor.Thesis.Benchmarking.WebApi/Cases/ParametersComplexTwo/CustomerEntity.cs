namespace Bachelor.Thesis.Benchmarking.WebApi.Cases.ParametersComplexTwo;

public class CustomerEntity
{
    public int Id { get; set; }
    public Guid CustomerId { get; set; }

    public string User { get; set; } = string.Empty;

    public string Address { get; set; } = string.Empty;
}