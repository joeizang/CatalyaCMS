using System;
using System.Collections.Generic;
using System.Text;
using CatalyaCMS.Domain.ApiModels;
using CatalyaCMS.Infrastructure.Abstractions;

namespace CatalyaCMS.Infrastructure.Events
{
    public class ArticleCreateEvent : IDomainEvent
    {
        public DateTimeOffset EventRaisedAt { get; set; }

        public ArticleCreateModel CreateModel { get; set; }

        public ArticleCreateEvent(ArticleCreateModel model)
        {
            
        }
    }
}
