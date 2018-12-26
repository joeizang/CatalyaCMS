using System;
using System.Collections.Generic;
using System.Text;
using CatalyaCMS.Domain.BaseTypes;

namespace CatalyaCMS.Domain.DomainModels
{
    public class Commentator : BaseEntity
    {
        public Commentator()
        {
            Status = Status.Member;
            Comments = new List<Comment>();
        }

        public string FullName { get; set; }

        public string EmailAddress { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public Status Status { get; set; }
    }
}
