using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CatalyaCMS.Domain.BaseTypes;

namespace CatalyaCMS.Infrastructure.Abstractions
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<List<T>> GetListAsync(IQuerySpecification<T> query = null, CancellationToken cancelToken = default,
            params Expression<Func<T, object>>[] includes);

        IQueryable<T> Query(IQuerySpecification<T> filters, Expression<Func<T, object>>[] inlcudes);

        IQueryable<T> Query(IncludeParams<T> param, IQuerySpecification<T> filters);


        ValueTask<T> FindBy(string id, CancellationToken cancelToken = default);

        ValueTask<T> FindBy(int id, CancellationToken cancelToken = default);

        Task<T> FindOne(CancellationToken cancelToken = default, params Expression<Func<T,bool>>[] predicates);

        bool Remove(string id);

        bool Remove(int id);

        bool Remove(T entity);

        void Add(T entity);

        void Update(T entity);

        Task<int> Commit(CancellationToken token);
    }
}
