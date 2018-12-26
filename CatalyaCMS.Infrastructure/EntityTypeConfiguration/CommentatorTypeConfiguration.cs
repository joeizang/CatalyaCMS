using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CatalyaCMS.Domain.DomainModels;

namespace CatalyaCMS.Infrastructure.EntityTypeConfiguration
{
    public class CommentatorTypeConfiguration : IEntityTypeConfiguration<Commentator>
    {
        public void Configure(EntityTypeBuilder<Commentator> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.EmailAddress).HasMaxLength(50).IsRequired();
            builder.Property(c => c.FullName).HasMaxLength(60).IsRequired();
            builder.Property(c => c.Status).IsRequired();
        }
    }
}
