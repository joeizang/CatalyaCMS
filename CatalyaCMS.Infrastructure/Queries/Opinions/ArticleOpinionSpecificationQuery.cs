using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CatalyaCMS.Domain.DomainModels;
using CatalyaCMS.Infrastructure.Abstractions;

namespace CatalyaCMS.Infrastructure.Queries.Opinions
{
    public class ArticleOpinionSpecificationQuery : BaseQuerySpecification<Article>
    {
        private readonly string _opinionId;
        private readonly string _siteUserId;

        public ArticleOpinionSpecificationQuery(string opinionId, string siteUserId)
        {
            _opinionId = opinionId ?? string.Empty;
            _siteUserId = siteUserId ?? string.Empty;
        }
        
        /// <summary>
        /// Predicate for Opinions associated with any article and specific
        /// member.
        /// </summary>
        public override List<Expression<Func<Article, bool>>> Predicates =>
            new List<Expression<Func<Article, bool>>>
            {
                a => a.Opinions.Single().Id.Equals(_opinionId, StringComparison.InvariantCultureIgnoreCase),
                a => a.SiteUserId.Equals(_siteUserId, StringComparison.InvariantCultureIgnoreCase)
            };
    }
}