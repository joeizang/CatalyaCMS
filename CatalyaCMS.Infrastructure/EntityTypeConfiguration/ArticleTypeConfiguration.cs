using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CatalyaCMS.Domain.DomainModels;

namespace CatalyaCMS.Infrastructure.EntityTypeConfiguration
{
    public class ArticleTypeConfiguration : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Title).HasMaxLength(50).IsRequired();
            builder.HasIndex(a => a.Title).IsUnique();
            builder.Property(a => a.Body).HasMaxLength(1500).IsRequired();
            builder.HasMany(a => a.Pictures).WithOne().IsRequired(false);
            builder.HasOne(a => a.SiteUser).WithMany(a => a.Articles)
                   .IsRequired().HasForeignKey(a => a.SiteUserId).OnDelete(DeleteBehavior.Cascade);
            builder.HasQueryFilter(a => a.IsDeleted);
        }
    }
}
