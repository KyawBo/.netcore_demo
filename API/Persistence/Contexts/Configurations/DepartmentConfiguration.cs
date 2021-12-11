using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using API.Domain.Models;

namespace API.Persistence.Contexts.Configurations
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable("Department");
            builder.HasKey(e => e.DepartmentId);
            builder.Property(e => e.DepartmentId).IsRequired().HasMaxLength(36).ValueGeneratedOnAdd().HasColumnType("char");
            builder.Property(e => e.Description).IsRequired().HasMaxLength(500).HasColumnType("nvarchar");
            builder.Property(e => e.Code).IsRequired().HasMaxLength(10).HasColumnType("varchar");
            builder.Property(e => e.TS).IsRequired();
            builder.HasMany(e => e.Employees).WithOne(e => e.Department).HasForeignKey(e => e.DepartmentId);
        }
    }
}
