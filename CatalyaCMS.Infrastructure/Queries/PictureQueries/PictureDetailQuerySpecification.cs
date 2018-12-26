using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using CatalyaCMS.Domain.DomainModels;
using CatalyaCMS.Infrastructure.Abstractions;

namespace CatalyaCMS.Infrastructure.Queries.PictureQueries
{
    public class PictureDetailQuerySpecification : BaseQuerySpecification<Picture>
    {

        private string _id;

        private string _title;


        public PictureDetailQuerySpecification(string id, string title)
        {
            _id = id;
            _title = title;
        }

        public override List<Expression<Func<Picture, bool>>> Predicates =>
            new List<Expression<Func<Picture, bool>>>
            {
                p => p.Id.Equals(_id, StringComparison.InvariantCultureIgnoreCase),
                p => p.Title.Equals(_title, StringComparison.InvariantCultureIgnoreCase)
            };
    }
}
