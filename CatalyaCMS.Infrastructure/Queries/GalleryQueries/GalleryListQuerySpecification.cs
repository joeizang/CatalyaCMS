using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using CatalyaCMS.Domain.DomainModels;
using CatalyaCMS.Infrastructure.Abstractions;

namespace CatalyaCMS.Infrastructure.Queries.GalleryQueries
{
    public class GalleryListQuerySpecification : BaseQuerySpecification<Gallery>
    {
        public override Expression<Func<Gallery, object>> OrderBy => g => g.CreatedDate;

        public override Expression<Func<Gallery, object>> ThenBy => g => g.GalleryName;

        public override int Skip { get; protected set; } = 5;

        public override int Take { get; protected set; } = 10;
    }
}
