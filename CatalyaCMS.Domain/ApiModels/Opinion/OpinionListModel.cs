using System;

namespace CatalyaCMS.Domain.ApiModels.Opinion
{
    public class OpinionListModel
    {
        public string OpinionId { get; set; }

        public string MemberId { get; set; }

        public string ArticleId { get; set; }

        public DateTimeOffset ArticleDate { get; set; }

        public int LikeCount { get; set; }

        public int DisLikeCount { get; set; }

        public int CommentCount { get; set; }
        
    }
}