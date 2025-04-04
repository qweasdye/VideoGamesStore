using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VideoGameStore.Core.Models;
using VideoGameStore.DataAccess.Entities;

namespace VideoGameStore.DataAccess.Configurations
{
    public class VideoGameConfiguration : IEntityTypeConfiguration<VideoGameEntity>
    {
        public void Configure(EntityTypeBuilder<VideoGameEntity> builder)
        {
            builder.HasKey(i => i.Id);

            builder.Property(t => t.Title)
                .HasMaxLength(VideoGame.MAX_TITLE_LENGTH)
                .IsRequired();

            builder.Property(platf => platf.Platform)
                .IsRequired();

            builder.Property(d => d.Developer)
                .IsRequired();

            builder.Property(p => p.Price)
                .IsRequired();
        }
    }
}
