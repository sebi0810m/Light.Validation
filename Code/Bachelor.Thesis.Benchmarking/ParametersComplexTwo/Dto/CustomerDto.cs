using System.ComponentModel.DataAnnotations;

namespace Bachelor.Thesis.Benchmarking.ParametersComplexTwo.Dto;

public class CustomerDto : IValidatableObject
{
    public static CustomerDto ValidCustomerDto = new()
    {
        CustomerId = Guid.NewGuid(),
        User = User.ValidUser, 
        Address = Address.ValidAddress
    };

    public static CustomerDto InvalidCustomerDto = new()
    {
        CustomerId = Guid.NewGuid(),
        User = User.InvalidUser, 
        Address = Address.InvalidAddress
    };

    public Guid CustomerId { get; set; } 

    [Required]
    public User User { get; set; } = new ();

    [Required]
    public Address Address { get; set; } = new ();

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        var resultsUser = new List<ValidationResult>();
        var resultsAddress = new List<ValidationResult>();
        var results = new List<ValidationResult>();

        // TODO: ModelValidation only validates with [Required] attribute, ignores other attributes

        Validator.TryValidateObject(User, new ValidationContext(User), resultsUser);
        results.AddRange(resultsUser);

        Validator.TryValidateObject(Address, new ValidationContext(Address), resultsAddress);
        results.AddRange(resultsAddress);

        return results;
    }
}