using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace CatalyaCMS.Infrastructure.Abstractions
{
    public interface IQuerySpecification<T> where T : class
    {
        List<Expression<Func<T, bool>>> Predicates { get; }

        Expression<Func<T, object>> OrderBy { get; }

        Expression<Func<T, object>> ThenBy { get; }

        Expression<Func<T, object>> OrderByDescending { get; }

        Expression<Func<T, object>> ThenByDescending { get; }

        int Take { get; }

        int Skip { get; }
    }
}
