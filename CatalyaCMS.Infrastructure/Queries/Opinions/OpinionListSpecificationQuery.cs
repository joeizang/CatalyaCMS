using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using CatalyaCMS.Domain.DomainModels;
using CatalyaCMS.Infrastructure.Abstractions;

namespace CatalyaCMS.Infrastructure.Queries.Opinions
{
    public class OpinionListSpecificationQuery : BaseQuerySpecification<Opinion>
    {
        private string _id;

        public OpinionListSpecificationQuery(string id)
        {
            _id = id;
        }

        public OpinionListSpecificationQuery()
        {
            
        }

        public override List<Expression<Func<Opinion, bool>>> Predicates =>
            new List<Expression<Func<Opinion, bool>>>
            {
                o => o.SiteUserId.Equals(_id)
            };

        public override Expression<Func<Opinion, object>> OrderByDescending =>
            o => o.Like;

        public override Expression<Func<Opinion, object>> OrderBy =>
            o => o.CreatedDate;
    }
}