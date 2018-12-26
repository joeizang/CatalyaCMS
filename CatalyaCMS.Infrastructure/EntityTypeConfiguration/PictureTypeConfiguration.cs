using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CatalyaCMS.Domain.DomainModels;

namespace CatalyaCMS.Infrastructure.EntityTypeConfiguration
{
    public class PictureTypeConfiguration : IEntityTypeConfiguration<Picture>
    {
        public void Configure(EntityTypeBuilder<Picture> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Title).HasMaxLength(50).IsRequired();
            builder.HasIndex(p => p.Title).IsUnique();
            builder.Property(p => p.Description).HasMaxLength(200).IsRequired();
            builder.Property(p => p.PicturePath).IsRequired().HasMaxLength(300);
            builder.HasMany(p => p.Tags).WithOne().IsRequired().OnDelete(DeleteBehavior.Cascade);
            builder.HasQueryFilter(p => p.IsDeleted);
        }
    }
}
