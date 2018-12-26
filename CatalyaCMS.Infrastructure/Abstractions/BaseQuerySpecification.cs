using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using CatalyaCMS.Domain.BaseTypes;

namespace CatalyaCMS.Infrastructure.Abstractions
{
    public abstract class BaseQuerySpecification<T> : IQuerySpecification<T> where T : BaseEntity 
    {
        public virtual List<Expression<Func<T, bool>>> Predicates => null;

        public virtual Expression<Func<T, object>> OrderBy => null;

        public virtual Expression<Func<T, object>> ThenBy => null;

        public virtual Expression<Func<T, object>> OrderByDescending => null;

        public virtual Expression<Func<T, object>> ThenByDescending => null;

        public virtual int Take { get; protected set; } = 0;

        public virtual int Skip { get; protected set; } = 0;
    }
}
