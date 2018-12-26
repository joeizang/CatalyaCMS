using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using CatalyaCMS.Domain.BaseTypes;

namespace CatalyaCMS.Domain.DomainModels
{
    public class SiteRole : IdentityRole, IBaseEntity
    {
        public bool IsDeleted { get; private set; }
        public void Delete()
        {
            IsDeleted = true;
        }

        public DateTimeOffset CreatedDate { get; private set; }
        public DateTimeOffset UpdatedDate { get; private set; }
    }
}
