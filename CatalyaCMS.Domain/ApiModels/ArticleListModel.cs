using System;
using System.Collections.Generic;
using System.Text;

namespace CatalyaCMS.Domain.ApiModels
{
    public class ArticleListModel
    {
        public string ArticleTitle { get; set; }

        public string AuthorName { get; set; }

        public string PublishedDate { get; set; }

        public int Tags { get; set; }

        public string Id { get; set; }
    }
}
