using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using CatalyaCMS.Domain.BaseTypes;

namespace CatalyaCMS.Domain.DomainModels
{
    public class SiteUser : IdentityUser, IBaseEntity
    {

        public string AuthorName { get; set; }

        public string Designation { get; set; }

        public bool? IsStaff { get; set; }

        public string Photo { get; set; }

        public ICollection<Article> Articles { get; set; }

        public bool IsDeleted { get; private set; }

        public void Delete()
        {
            IsDeleted = true;
        }

        public DateTimeOffset CreatedDate { get; private set; }

        public DateTimeOffset UpdatedDate { get; private set; }
    }
}