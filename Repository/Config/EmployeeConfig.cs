using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Config
{
    public class EmployeeConfig : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasData(
                new Employee
                {
                    Id =new Guid("9a13fdc9-4167-405b-8e40-1cde0bdee2a6"),
                    ProjectId=new Guid("b2d3b0df-6c13-4d20-8d3d-09b003acc13f"),
                    FirstName="YAKUP",
                    LastName="YILDIRIM",
                    Age=19,
                    Position="Senior Developer"

                });

        }
    }
}
