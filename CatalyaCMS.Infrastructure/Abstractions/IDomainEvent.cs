using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace CatalyaCMS.Infrastructure.Abstractions
{
    public interface IDomainEvent : INotification
    {
        DateTimeOffset EventRaisedAt { get; set; }
    }
}
