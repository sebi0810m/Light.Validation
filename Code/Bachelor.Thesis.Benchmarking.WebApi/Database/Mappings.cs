using Bachelor.Thesis.Benchmarking.ParametersPrimitiveAll;
using Bachelor.Thesis.Benchmarking.ParametersPrimitiveTwo;
using Bachelor.Thesis.Benchmarking.WebApi.Cases.CollectionComplex;
using Bachelor.Thesis.Benchmarking.WebApi.Cases.CollectionFlat;
using Bachelor.Thesis.Benchmarking.WebApi.Cases.ParametersComplexTwo;
using LinqToDB.Mapping;

namespace Bachelor.Thesis.Benchmarking.WebApi.Database;

public static class Mappings
{
    public static void AddMappingsForEntities(this MappingSchema schema)
    {
        var mappingBuilder = schema.GetFluentMappingBuilder();

        // ParametersPrimitiveTwo
        mappingBuilder.Entity<UserDto>()
                      .HasTableName("ParametersPrimitiveTwo")
                      .Property(user => user.Id).IsIdentity().IsPrimaryKey()
                      .Property(user => user.Name).IsNullable(false);

        // ParametersPrimitiveAll
        mappingBuilder.Entity<EmployeeDto>()
                      .HasTableName("ParametersPrimitiveAll")
                      .Property(employee => employee.Id).IsIdentity().IsPrimaryKey()
                      .Property(employee => employee.Guid).IsNullable(false)
                      .Property(employee => employee.Name).IsNullable(false)
                      .Property(employee => employee.Position).IsNullable(false)
                      .Property(employee => employee.Department).IsNullable(false)
                      .Property(employee => employee.WeeklyWorkingHours).IsNullable(false)
                      .Property(employee => employee.EmployeeId).IsNullable(false)
                      .Property(employee => employee.ProductivityScore).IsNullable(false)
                      .Property(employee => employee.OvertimeWorked).IsNullable(false)
                      .Property(employee => employee.HourlySalary).IsNullable(false)
                      .Property(employee => employee.DateEmployed).IsNullable(false);

        // ParametersComplexTwo
        mappingBuilder.Entity<CustomerEntity>()
                      .HasTableName("ParametersComplexTwo")
                      .Property(customer => customer.Id).IsIdentity().IsPrimaryKey()
                      .Property(customer => customer.Guid).IsNullable(false)
                      .Property(customer => customer.Address).IsNullable(false)
                      .Property(customer => customer.User).IsNullable(false);

        // CollectionFlat
        mappingBuilder.Entity<CollectionFlatEntity>()
                      .HasTableName("CollectionFlat")
                      .Property(collection => collection.Id).IsIdentity().IsPrimaryKey()
                      .Property(collection => collection.Guid).IsNullable(false)
                      .Property(collection => collection.Names).IsNullable(false)
                      .Property(collection => collection.Availability).IsNullable(false);

        // CollectionComplex
        mappingBuilder.Entity<CollectionComplexEntity>()
                      .HasTableName("CollectionComplex")
                      .Property(collection => collection.Id).IsIdentity().IsPrimaryKey()
                      .Property(collection => collection.Guid).IsNullable(false)
                      .Property(collection => collection.OrderDetailsList).IsNullable(false)
                      .Property(collection => collection.ArticleList).IsNullable(false);
    }
}