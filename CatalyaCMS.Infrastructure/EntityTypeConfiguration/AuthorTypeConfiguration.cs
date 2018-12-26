using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CatalyaCMS.Domain.DomainModels;

namespace CatalyaCMS.Infrastructure.EntityTypeConfiguration
{
    public class AuthorTypeConfiguration : IEntityTypeConfiguration<SiteUser>
    {
        public void Configure(EntityTypeBuilder<SiteUser> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.AuthorName).HasMaxLength(50).IsRequired();
            builder.HasIndex(a => a.AuthorName).IsUnique();
            builder.Property(a => a.Designation).HasMaxLength(15).IsRequired(false);
            builder.Property(a => a.Photo).IsRequired().HasMaxLength(300);
            builder.Property(a => a.IsStaff).IsRequired(false);
            builder.HasQueryFilter(a => a.IsDeleted.Equals(true));
        }
    }
}
