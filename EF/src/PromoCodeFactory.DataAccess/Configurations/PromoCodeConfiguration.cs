using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PromoCodeFactory.Core.Domain.PromoCodeManagement;

namespace PromoCodeFactory.DataAccess.Configurations;

public class PromoCodeConfiguration : IEntityTypeConfiguration<PromoCode>
{
    public void Configure(EntityTypeBuilder<PromoCode> builder)
    {
        builder.ConfigureBaseEntity();

        builder.Property(x => x.Code)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(x => x.ServiceInfo)
            .HasMaxLength(200);

        builder.Property(x => x.BeginDate)
            .IsRequired();

        builder.Property(x => x.EndDate)
            .IsRequired();

        builder.Property(x => x.PartnerName)
            .HasMaxLength(50);

        builder.HasOne(x => x.PartnerManager)
            .WithMany()
            .HasForeignKey(x => x.PartnerManagerId);

        builder.HasOne(x => x.Preference)
            .WithMany()
            .HasForeignKey(x => x.PreferenceId);
    }
}
