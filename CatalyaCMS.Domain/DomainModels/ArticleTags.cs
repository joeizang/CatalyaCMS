using System;
using System.Collections.Generic;
using System.Text;
using CatalyaCMS.Domain.BaseTypes;

namespace CatalyaCMS.Domain.DomainModels
{
    public class ArticleTags : BaseEntity
    {

        public string ArticleId { get; set; }

        public Article Article { get; set; }

        public Tag Tag { get; set; }

        public string TagId { get; set; }
    }
}
