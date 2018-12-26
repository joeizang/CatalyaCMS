using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using CatalyaCMS.Domain.DomainModels;
using CatalyaCMS.Infrastructure.Abstractions;

namespace CatalyaCMS.Infrastructure.Queries.Articles
{
    public class ArticleDetailQuerySpecification : BaseQuerySpecification<Article>
    {
        public ArticleDetailQuerySpecification()
        {
        }

        public ArticleDetailQuerySpecification(string id)
        {
            Predicates = new List<Expression<Func<Article, bool>>>
            {
                x => x.Id.Equals(id)
            };
        }

        public override List<Expression<Func<Article, bool>>> Predicates { get; }
    }
}
