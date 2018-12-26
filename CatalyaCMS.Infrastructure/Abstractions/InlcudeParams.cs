using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using CatalyaCMS.Domain.BaseTypes;

namespace CatalyaCMS.Infrastructure.Abstractions
{
    public class IncludeParams<T> where T : BaseEntity
    {
        /// <summary>
        /// Add Includes for EF. If the relationship is deep, then seperate them
        /// with . eg. Student.Course.Teachers
        /// </summary>
        public List<Expression<Func<T, object>>> Includes { get; set; }

    }
}