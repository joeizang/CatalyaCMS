using System;
using System.Collections.Generic;
using System.Text;
using CatalyaCMS.Domain.BaseTypes;

namespace CatalyaCMS.Domain.DomainModels
{
    public class Tag : BaseEntity
    {
        private Tag()
        {
            ArticleTags = new List<ArticleTags>();
        }

        public Tag(string tagName)
        {
            List<ArticleTags> ArticleTags = new();
        }

        public Tag(DateTimeOffset createdDate, bool delete = false)
        {
            CreatedDate = createdDate;
        }

        public string Name { get; set; }

        public ICollection<ArticleTags> ArticleTags { get; set; }
    }
}
