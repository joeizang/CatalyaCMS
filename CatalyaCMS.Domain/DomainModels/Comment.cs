using System;
using System.Collections.Generic;
using System.Text;
using CatalyaCMS.Domain.BaseTypes;

namespace CatalyaCMS.Domain.DomainModels
{
    public class Comment : BaseEntity
    {
        public Comment()
        {
            Opinions = new List<Opinion>();
        }

        public string ArticleId { get; set; }

        public DateTimeOffset CommentDate { get; set; }

        public bool? IsReply { get; set; }
        
        public string CommentBody { get; set; }


        public List<Opinion> Opinions { get; set; }
        
        public string ParentCommentId { get; set; }
    }
}
