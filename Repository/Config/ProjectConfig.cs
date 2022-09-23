using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Config
{
    public class ProjectConfig : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasData(
                new Project
                {
                    Id=new Guid("b2d3b0df-6c13-4d20-8d3d-09b003acc13f"),
                    Name="ASP.NET CORE Web API Project",
                    Description="Web Aplication Programing Interface",
                    Field="Computer Science"
                });
        }
        
    }
}
