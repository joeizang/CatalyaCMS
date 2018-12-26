using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using CatalyaCMS.Domain.ApiModels;
using CatalyaCMS.Domain.ApiModels.Gallery;
using CatalyaCMS.Domain.ApiModels.Picture;
using CatalyaCMS.Domain.DomainModels;
using CatalyaCMS.Infrastructure.Abstractions;
using CatalyaCMS.Infrastructure.Context;
using CatalyaCMS.Infrastructure.Queries;
using CatalyaCMS.Infrastructure.Queries.Articles;
using CatalyaCMS.Infrastructure.Repositories;
using Xunit;

namespace CatalyaCMS.Tests.RepositoryTests
{
    public class ArticleRepositoryTests : IDisposable
    {
        public DbContextOptions<SiteDbContext> Options { get; }

        public GenericRepository<Article> Repo { get; }

        public SiteDbContext Context { get; }

        public ArticleRepositoryTests()
        {
            SqliteConnection liteconn = new SqliteConnection("DataSource=..\\..\\..\\testdb.db3");
            Options = new DbContextOptionsBuilder<SiteDbContext>().UseSqlite(liteconn).Options;
            Context = new SiteDbContext(Options);
            
            if(Context.Database.EnsureCreated() && !Context.Articles.Any())
                CreateArticles();
            

            Repo = new ArticleRepository(Context);
        }

        public void Dispose()
        {
            Context.Dispose();
        }

        private void CreateArticles()
        {
            var siteuser = new SiteUser
            {
                Articles = new List<Article>(),
                AuthorName = "Test User",
                Email = "testuser@user.com",
                UserName = "testuser@user.com",
                PhoneNumber = "08023753028",
                EmailConfirmed = true,
                Designation = "contributor",
                IsStaff = false,
                Id = Guid.NewGuid().ToString(),
                Photo = "SomePath"
            };

            var articles = new List<Article>
            {
                new Article
                {
                    ArticleTags = new List<ArticleTags>(),
                    Assets = new List<Asset>(),
                    Body = "Some Text",
                    //CreatedDate = DateTimeOffset.UtcNow,
                    Opinions = new List<Opinion>(),
                    Pictures = new List<Picture>(),
                    Title = "Some Text Title",
                    SiteUser = siteuser
                },
                new Article
                {
                    ArticleTags = new List<ArticleTags>
                    {
                        new ArticleTags()
                    },
                    Assets = new List<Asset>
                    {
                        new Asset()
                    },
                    Body = "Some Text",
                    //CreateDate = DateTimeOffset.UtcNow,
                    Opinions = new List<Opinion>(),
                    Pictures = new List<Picture>
                    {
                        new Picture(new PictureCreateModel())
                        {
                            Gallery = new Gallery(new GalleryCreateModel()),
                            Tags = new List<Tag>
                            {
                                new Tag
                                {
                                    ArticleTags = new List<ArticleTags>
                                    {
                                        new ArticleTags()
                                    }
                                }
                            }
                        }
                    },
                    Title = "Some Text Title",
                    SiteUser = siteuser
                }
            };
            Context.Articles.AddRange(articles);
            Context.SaveChanges();
        }

        [Fact]
        public void QueryWithNullInclude_ReturnsIQueryable()
        {
            var query = new ArticleListQuerySpecification();
            var result = Repo.Query(query, null);
            Assert.IsAssignableFrom<IQueryable<Article>>(result);
        }

        [Fact]
        public void QueryWithNullIQuery_ReturnsIQueryable()
        {
            var query = new ArticleListQuerySpecification();
            var result = Repo.Query(null, a => a.Title.Equals("Some Text Title"));
            Assert.IsAssignableFrom<IQueryable<Article>>(result);
        }

        [Fact]
        public void QueryWithIQueryAndInclude_ReturnsIQueryable()
        {
            var query = new ArticleListQuerySpecification();
            var result = Repo.Query(query, a => a.Title.Equals("Some Text Title"));
            Assert.IsAssignableFrom<IQueryable<Article>>(result);
        }

        [Fact]
        public void QueryWithIQueryAndIncludeParams()
        {
            var parms = new IncludeParams<Article>
            {
                Includes = new List<Expression<Func<Article, object>>> {x => x.Assets, x => x.ArticleTags}
            };

            var query = new ArticleListQuerySpecification();

            var result = Repo.Query(parms, query);

            Assert.IsAssignableFrom<IQueryable<Article>>(result);
        }

        [Fact]
        public void QueryWithIncludeParamsNullAndNullIQuery()
        {
            ArticleListQuerySpecification q = null;
            var result = Repo.Query(null, q);
            Assert.IsAssignableFrom<IQueryable<Article>>(result);
        }
    }

    
}
