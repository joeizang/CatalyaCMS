using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using CatalyaCMS.Domain.DomainModels;
using CatalyaCMS.Infrastructure.Abstractions;

namespace CatalyaCMS.Infrastructure.Queries.PictureQueries
{
    public class PictureListQuerySpecification : BaseQuerySpecification<Picture>
    {
        public override Expression<Func<Picture, object>> OrderBy => p => p.CreatedDate;

        public override Expression<Func<Picture, object>> ThenBy => p => p.Title;

        public override List<Expression<Func<Picture, bool>>> Predicates =>
            new List<Expression<Func<Picture, bool>>>
            {
                p => !string.IsNullOrEmpty(p.GalleryId)
            };

        public override int Skip { get; protected set; } = 5;

        public override int Take { get; protected set; } = 10;
    }
}
