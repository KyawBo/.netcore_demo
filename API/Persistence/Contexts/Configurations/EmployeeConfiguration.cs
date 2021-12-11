using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using API.Domain.Models;

namespace API.Persistence.Contexts.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employee");
            builder.HasKey(e => e.EmployeeId);
            builder.Property(e => e.EmployeeId).IsRequired().HasMaxLength(36).ValueGeneratedOnAdd().HasColumnType("char");
            builder.Property(e => e.EmployeeName).IsRequired().HasMaxLength(500).HasColumnType("nvarchar");
            builder.Property(e => e.EmployeeNo).IsRequired().HasMaxLength(10).HasColumnType("varchar");
            builder.Property(e => e.DOB).IsRequired();
            builder.Property(e => e.TS).IsRequired();
            builder.Property(e => e.Salary).HasPrecision(10,2);
        }
    }
}
