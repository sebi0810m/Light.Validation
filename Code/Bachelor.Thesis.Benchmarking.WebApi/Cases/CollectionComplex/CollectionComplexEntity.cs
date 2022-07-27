namespace Bachelor.Thesis.Benchmarking.WebApi.Cases.CollectionComplex;

public class CollectionComplexEntity
{
    public int Id { get; set; }

    public Guid Guid { get; set; }

    public string OrderDetailsList { get; set; } = string.Empty;

    public string ArticleList { get; set; } = string.Empty;
}