using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CatalyaCMS.Domain.DomainModels;

namespace CatalyaCMS.Infrastructure.EntityTypeConfiguration
{
    public class TagTypeConfiguration : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Name).HasMaxLength(50).IsRequired();
            builder.HasIndex(t => t.Name).IsUnique();
            builder.HasQueryFilter(t => t.IsDeleted);
        }
    }
}
