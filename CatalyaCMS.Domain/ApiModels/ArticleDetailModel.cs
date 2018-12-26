using System;
using System.Collections.Generic;
using System.Text;

namespace CatalyaCMS.Domain.ApiModels
{
    public class ArticleDetailModel
    {
        public string Id { get; set; }

        public string AuthorName { get; set; }

        public int ArticleLength { get; set; }

        public DateTimeOffset CreatedOn { get; set; }

        public int NumberOfArtcileByAuthor { get; set; }

        public int NumberOfLikes { get; set; }

        public string ArticleBody { get; set; }

        public string PublishedOn { get; set; }

        public string ArticleTitle { get; set; }
    }
}
