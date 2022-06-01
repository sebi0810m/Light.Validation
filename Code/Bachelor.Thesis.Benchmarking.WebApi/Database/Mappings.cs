using Bachelor.Thesis.Benchmarking.ParametersPrimitiveAll;
using Bachelor.Thesis.Benchmarking.ParametersPrimitiveTwo;
using LinqToDB.Mapping;

namespace Bachelor.Thesis.Benchmarking.WebApi.Database;

public static class Mappings
{
    public static void AddMappingsForEntities(this MappingSchema schema)
    {
        var mappingBuilder = schema.GetFluentMappingBuilder();

        mappingBuilder.Entity<UserDto>()
                      .HasTableName("ParametersPrimitiveTwo")
                      .Property(user => user.Id).IsIdentity().IsPrimaryKey()
                      .Property(user => user.Name).IsNullable(false);

        mappingBuilder.Entity<EmployeeDto>()
                      .HasTableName("ParametersPrimitiveAll")
                      .Property(employee => employee.Id).IsIdentity().IsPrimaryKey()
                      .Property(employee => employee.Name).IsNullable(false)
                      .Property(employee => employee.Position).IsNullable(false)
                      .Property(employee => employee.Department).IsNullable(false)
                      .Property(employee => employee.WeeklyWorkingHours).IsNullable(false)
                      .Property(employee => employee.EmployeeId).IsNullable(false)
                      .Property(employee => employee.ProductivityScore).IsNullable(false)
                      .Property(employee => employee.OvertimeWorked).IsNullable(false)
                      .Property(employee => employee.HourlySalary).IsNullable(false)
                      .Property(employee => employee.DateEmployed).IsNullable(false);
    }
}