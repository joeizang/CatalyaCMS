using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CatalyaCMS.Domain.DomainModels;

namespace CatalyaCMS.Infrastructure.EntityTypeConfiguration
{
    public class ArticleTagsTypeConfiguration : IEntityTypeConfiguration<ArticleTags>
    {
        public void Configure(EntityTypeBuilder<ArticleTags> builder)
        {
            builder.HasKey(at => at.Id);
            builder.HasOne(at => at.Article).WithMany(a => a.ArticleTags)
                .HasForeignKey(at => at.ArticleId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(at => at.Tag).WithMany(p => p.ArticleTags).HasForeignKey(p => p.TagId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasQueryFilter(at => at.IsDeleted);
        }
    }
}
