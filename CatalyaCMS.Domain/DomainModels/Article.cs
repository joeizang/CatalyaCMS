using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CatalyaCMS.Domain.ApiModels;
using CatalyaCMS.Domain.BaseTypes;

namespace CatalyaCMS.Domain.DomainModels
{
    public class Article : BaseEntity
    {

        private ArticleCreateModel CreateStateTracker { get; set; }

        public Article(ArticleCreateModel model)
        {
            ArticleTags = new List<ArticleTags>();
            Assets = new List<Asset>();
            Pictures = new List<Picture>();
            Opinions = new List<Opinion>();

            CreateStateTracker = model;

            Title = CreateStateTracker.ArticleTitle;
            Body = CreateStateTracker.ArticleBody;
            CreatedDate = DateTimeOffset.UtcNow;
        }

        public Article()
        {
            ArticleTags = new List<ArticleTags>();
            Assets = new List<Asset>();
            Pictures = new List<Picture>();
            Opinions = new List<Opinion>();
        }


        private void ArticlePublishAtCreation()
        {
            if (CreateStateTracker.Publish)
            {
                PublishDate = DateTimeOffset.UtcNow;
            }
        }

        private void AddTags()
        {
            if (!CreateStateTracker.Tags.Any()) return;
            foreach (var tag in CreateStateTracker.Tags)
            {
                ArticleTags.Add(new ArticleTags
                {
                    Article = this, Tag = new Tag(DateTimeOffset.UtcNow)
                });
            }
        }


        public string Title { get; set; }

        public string Body { get; set; }

        public DateTimeOffset? PublishDate { get; set; }

        public ICollection<Asset> Assets { get; set; }

        public ICollection<Picture> Pictures { get; set; }
        
        public SiteUser SiteUser { get; set; } //Authors
        
        public string SiteUserId { get; set; }

        public ICollection<ArticleTags> ArticleTags { get; set; }

        public ICollection<Opinion> Opinions { get; set; }
    }
}
