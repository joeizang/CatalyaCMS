using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CatalyaCMS.Domain.DomainModels;

namespace CatalyaCMS.Infrastructure.EntityTypeConfiguration
{
    public class AssetTypeConfiguration : IEntityTypeConfiguration<Asset>
    {
        public void Configure(EntityTypeBuilder<Asset> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.AssetName).HasMaxLength(50).IsRequired();
            builder.HasIndex(c => c.AssetName);
            builder.HasOne(a => a.Article).WithMany(a => a.Assets)
                   .HasForeignKey(a => a.ArticleId).IsRequired();
        }
    }
}
