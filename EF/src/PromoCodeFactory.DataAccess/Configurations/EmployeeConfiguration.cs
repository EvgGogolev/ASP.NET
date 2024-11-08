using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PromoCodeFactory.Core.Domain.Administration;

namespace PromoCodeFactory.DataAccess.Configurations;
public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.ConfigureBaseEntity();
        
        builder.Property(x => x.Email)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(x => x.FirstName)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(x => x.LastName)
            .IsRequired()
            .HasMaxLength(50);
        
        builder.Property(x => x.AppliedPromoCodesCount)
            .IsRequired();

        builder.HasOne(x => x.Role)
            .WithMany()
            .HasForeignKey(x => x.RoleId);
    }
}
