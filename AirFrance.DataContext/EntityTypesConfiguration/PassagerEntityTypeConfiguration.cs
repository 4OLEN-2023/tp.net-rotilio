using AirFrance.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirFrance.DataContext.EntityTypesConfiguration;

public class PassagerEntityTypeConfiguration : IEntityTypeConfiguration<Passager>
{
    public void Configure(EntityTypeBuilder<Passager> builder)
    {
        builder.HasOne(passager => passager.Vol)
               .WithMany(vol => vol.Passagers)
               .HasForeignKey(passager => passager.VolId);
    }
}
