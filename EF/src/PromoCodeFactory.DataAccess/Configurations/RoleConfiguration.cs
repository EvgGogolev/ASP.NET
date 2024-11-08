using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PromoCodeFactory.Core.Domain.Administration;

namespace PromoCodeFactory.DataAccess.Configurations;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ConfigureBaseEntity();

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(x => x.Description)
            .HasMaxLength(200);
    }
}

