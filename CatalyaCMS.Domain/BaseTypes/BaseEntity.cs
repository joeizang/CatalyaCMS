using System;
using System.Collections.Generic;
using System.Text;

namespace CatalyaCMS.Domain.BaseTypes
{
    public abstract class BaseEntity : IBaseEntity
    {
        public BaseEntity()
        {
            Id = Guid.NewGuid().ToString();
            CreatedDate = DateTimeOffset.UtcNow;
        }
        public string Id { get; protected set; }

        public bool IsDeleted { get; protected set; }

        public DateTimeOffset CreatedDate { get; protected set; }

        public DateTimeOffset UpdatedDate { get; set; }

        public virtual void Delete()
        {
            IsDeleted = true;
        }
    }
}
