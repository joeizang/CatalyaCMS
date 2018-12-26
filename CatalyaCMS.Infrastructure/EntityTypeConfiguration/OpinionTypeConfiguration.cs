using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CatalyaCMS.Domain.DomainModels;

namespace CatalyaCMS.Infrastructure.EntityTypeConfiguration
{
    public class OpinionTypeConfiguration : IEntityTypeConfiguration<Opinion>
    {
        public void Configure(EntityTypeBuilder<Opinion> builder)
        {
            builder.HasKey(o => o.Id);
            builder.HasIndex(o => o.SiteUserId);
            builder.HasOne(o => o.Article).WithMany(a => a.Opinions)
                .HasForeignKey(o => o.ArticleId);
            builder.HasOne(o => o.SiteUser).WithMany()
                .HasForeignKey(o => o.SiteUserId);
        }
    }
}