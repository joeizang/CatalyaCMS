using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CatalyaCMS.Domain.DomainModels;

namespace CatalyaCMS.Infrastructure.EntityTypeConfiguration
{
    public class GalleryTypeConfiguration : IEntityTypeConfiguration<Gallery>
    {
        public void Configure(EntityTypeBuilder<Gallery> builder)
        {
            builder.HasKey(g => g.Id);
            builder.Property(g => g.GalleryName).HasMaxLength(50).IsRequired();
            builder.HasIndex(g => g.GalleryName).IsUnique();
            builder.Property(g => g.Description).HasMaxLength(200).IsRequired();
            builder.HasMany(g => g.Pictures).WithOne(p => p.Gallery)
                .HasForeignKey(p => p.GalleryId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasQueryFilter(g => g.IsDeleted.Equals(true));
        }
    }
}
