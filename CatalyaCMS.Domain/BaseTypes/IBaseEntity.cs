using System;

namespace CatalyaCMS.Domain.BaseTypes
{
    public interface IBaseEntity
    {
        string Id { get; }

        bool IsDeleted { get; }

        void Delete();

        DateTimeOffset CreatedDate { get; }

        DateTimeOffset UpdatedDate { get; }
    }
}