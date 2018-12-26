using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using CatalyaCMS.Domain.DomainModels;
using CatalyaCMS.Infrastructure.Abstractions;

namespace CatalyaCMS.Infrastructure.Queries.Opinions
{
    public class OpinionDetailSpecificationModel : BaseQuerySpecification<Opinion>
    {
        public OpinionDetailSpecificationModel(string id)
        {
            Predicates = new List<Expression<Func<Opinion, bool>>>
            {
                o => o.Id.Equals(id, StringComparison.InvariantCultureIgnoreCase)
            };
        }

        public override List<Expression<Func<Opinion, bool>>> Predicates { get; }
    }
}
