using System;
using System.Collections.Generic;
using System.Text;
using CatalyaCMS.Domain.BaseTypes;

namespace CatalyaCMS.Domain.DomainModels
{
    public class Tag : BaseEntity
    {
        public Tag()
        {
            ArticleTags = new List<ArticleTags>();
        }

        public Tag(DateTimeOffset createdDate, bool delete = false)
        {
            CreatedDate = createdDate;
        }

        public string Name { get; set; }

        public ICollection<ArticleTags> ArticleTags { get; set; }
    }
}
