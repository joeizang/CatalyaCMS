﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CatalyaCMS.Domain.ApiModels;
using CatalyaCMS.Domain.DomainModels;
using CatalyaCMS.Infrastructure.Abstractions;
using CatalyaCMS.Infrastructure.Queries;
using CatalyaCMS.Infrastructure.Queries.Articles;

namespace CatalyaCMS.Infrastructure.Services
{
    public class ArticleDataService
    {
        private readonly IRepository<Article> _repo;
        private readonly IDomainEvent _notify;
        private IncludeParams<Article> Parameters { get; set; } = new IncludeParams<Article>
        {
            Includes = new List<Expression<Func<Article, object>>>
            {
                x => x.Opinions,
                x => x.ArticleTags,
                x => x.Assets,
                x => x.SiteUser,
                x => x.Pictures
            }
        };


        public ArticleDataService(IRepository<Article> repo, IDomainEvent notification)
        {
            _repo = repo;
            _notify = notification;
        }

        public Task<List<ArticleListModel>> GetArticles(ArticleListQuerySpecification query)
        {
            
            var result = _repo.Query(Parameters, query);

            var results = result.AsNoTracking().Select(x => new ArticleListModel
            {
                ArticleTitle = x.Title,
                AuthorName = x.SiteUser.AuthorName,
                Id = x.Id,
                PublishedDate = x.PublishDate.Value.DateTime.ToString(CultureInfo.InvariantCulture),
                Tags = x.ArticleTags.Count
            }).ToListAsync();

            return results;
        }


        public Task<ArticleDetailModel> GetArticle(string id, ArticleDetailQuerySpecification detailSpec)
        {
            var result = _repo.Query(Parameters, detailSpec).AsNoTracking().Select(ad => new ArticleDetailModel
            {
                ArticleBody = ad.Body,
                ArticleLength = ad.Body.Count(),
                PublishedOn = ad.PublishDate.Value.DateTime.ToString(CultureInfo.InvariantCulture) ?? "Not Published",
                AuthorName = ad.SiteUser.AuthorName,
                CreatedOn = ad.CreatedDate,
                Id = ad.Id,
                NumberOfArtcileByAuthor = ad.SiteUser.Articles.Count,
                NumberOfLikes = ad.Opinions.Count,
                ArticleTitle = ad.Title,
            }).SingleOrDefaultAsync();

            return result;
        }

        public async Task UpdateArticle(string id, ArticleDetailModel model)
        {
            var article = await _repo.FindBy(model.Id).ConfigureAwait(false);
            article.Body = model.ArticleBody;
            article.GetType()
                .GetProperty(nameof(article.UpdatedDate))
                .SetValue(article.UpdatedDate,DateTimeOffset.UtcNow);
            article.GetType()
                .GetProperty(nameof(article.CreatedDate))
                .SetValue(article.CreatedDate, model.CreatedOn);
            article.Title = model.ArticleTitle;

            _repo.Update(article);
        }

        public void AddArticle(ArticleCreateModel model)
        {
            //search and create a siteuser object and add to the ArticleCreateModel object higher up
            //in the controller.
            var article = new Article(model);
            _repo.Add(article);
        }

        public int SaveChanges()
        {
            return _repo.Commit();
        }


    }
}
