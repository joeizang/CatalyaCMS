using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using CatalyaCMS.Domain.DomainModels;
using CatalyaCMS.Infrastructure.EntityTypeConfiguration;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.Extensions.Options;

namespace CatalyaCMS.Infrastructure.Context
{
    public class SiteDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {

        public SiteDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Article> Articles { get; set; }

        public DbSet<Asset> Assets { get; set; }

        public DbSet<ArticleTags> ArticleTags { get; set; }

        public DbSet<SiteUser> Authors { get; set; }

        public DbSet<SiteRole> SiteRoles { get; set; }

        public DbSet<Gallery> Galleries { get; set; }

        public DbSet<Picture> Pictures { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Opinion> Opinions { get; set; }

        public DbSet<Commentator> Commentators { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ArticleTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ArticleTagsTypeConfiguration());
            modelBuilder.ApplyConfiguration(new AuthorTypeConfiguration());
            modelBuilder.ApplyConfiguration(new GalleryTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PictureTypeConfiguration());
            modelBuilder.ApplyConfiguration(new TagTypeConfiguration());
            modelBuilder.ApplyConfiguration(new CommentatorTypeConfiguration());
            modelBuilder.ApplyConfiguration(new AssetTypeConfiguration());
            modelBuilder.ApplyConfiguration(new OpinionTypeConfiguration());
        }
    }
}
