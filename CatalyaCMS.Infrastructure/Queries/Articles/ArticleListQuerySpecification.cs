using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using CatalyaCMS.Domain.DomainModels;
using CatalyaCMS.Infrastructure.Abstractions;

namespace CatalyaCMS.Infrastructure.Queries.Articles
{
    public class ArticleListQuerySpecification : BaseQuerySpecification<Article>
    {
        public override Expression<Func<Article, object>> OrderBy => a => a.CreatedDate;
        public override int Take => 10;
        public override int Skip => 5;

        public override List<Expression<Func<Article, bool>>> Predicates =>
            new List<Expression<Func<Article, bool>>>
            {
                a => a.Title.Equals("Some Text Title")
            };
    }
}
