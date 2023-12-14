using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyVideoGames.Model;

namespace MyVideoGames.DataContext.EntityTypesConfiguration
{
    public class PlatformentityTypeConfiguration : IEntityTypeConfiguration<Platform>
    {
        public void Configure(EntityTypeBuilder<Platform> builder)
        {
            builder.HasKey(item => item.Id);

            builder.HasMany(item => item.RelatedGames);
        }
    }
}
