using System;
using System.Collections.Generic;
using System.Text;
using CatalyaCMS.Domain.BaseTypes;

namespace CatalyaCMS.Domain.DomainModels
{
    public class Asset : BaseEntity
    {

        public string AssetName { get; set; }

        public string Body { get; set; }

        public Article Article { get; set; }

        public string ArticleId { get; set; }
    }
}
