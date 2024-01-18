using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AirFrance.Model;

namespace AirFrance.DataContext.EntityTypesConfiguration;

public class VolEntityTypeConfiguration : IEntityTypeConfiguration<Vol>
{
    public void Configure(EntityTypeBuilder<Vol> builder)
    {
        builder.HasMany(vol => vol.Passagers)
               .WithOne(passager => passager.Vol)
               .HasForeignKey(passager => passager.VolId);
    }
}
