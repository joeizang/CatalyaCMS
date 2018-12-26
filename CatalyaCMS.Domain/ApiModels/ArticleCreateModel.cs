using System;
using System.Collections.Generic;
using System.Text;
using CatalyaCMS.Domain.ApiModels.Picture;

namespace CatalyaCMS.Domain.ApiModels
{
    public class ArticleCreateModel
    {
        public bool Publish { get; set; }

        public string ArticleTitle { get; set; }

        public string ArticleBody { get; set; }

        public string ArticleAuthor { get; set; }

        public DateTimeOffset CreatedDate { get; set; }

        public List<string> Tags { get; set; }

        public List<PictureCreateModel> Pictures { get; set; }

    }
}
