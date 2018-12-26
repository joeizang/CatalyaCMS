using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CatalyaCMS.Domain.DomainModels;

namespace CatalyaCMS.Infrastructure.EntityTypeConfiguration
{
    public class CommentTypeConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasIndex(c => c.Id);
            builder.Property(c => c.CommentBody)
                .HasMaxLength(500).IsRequired();
            builder.Property(c => c.ArticleId).IsRequired();
        }
    }
}