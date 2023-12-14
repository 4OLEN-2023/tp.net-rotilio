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
    public class GameEntityTypeConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.HasKey(item => item.Id);

            builder.HasOne(item => item.Platform)
                    .WithMany(item => item.RelatedGames)
                    .HasForeignKey(item => item.PlatformId);
        }
    }
}
