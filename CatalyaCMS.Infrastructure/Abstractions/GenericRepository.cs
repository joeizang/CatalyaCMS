using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CatalyaCMS.Domain.BaseTypes;
using CatalyaCMS.Infrastructure.Context;

namespace CatalyaCMS.Infrastructure.Abstractions
{
    public abstract class GenericRepository<T> : IRepository<T> where T : BaseEntity 
    {
        private readonly SiteDbContext _db;
        private readonly DbSet<T> _set;

        protected GenericRepository(SiteDbContext db)
        {
            _db = db;
            _set = _db.Set<T>();
        }

        /// <summary>
        /// Returns a Task of List<T> Filtered and Sorted or it will
        /// return everything from persistence
        /// </summary>
        /// <param name="query">Instance of IQuery with Expressions for Filtering, Sorting etc</param>
        /// <param name="cancelToken"></param>
        /// <param name="includes"></param>
        /// <returns></returns>
        public Task<List<T>> GetListAsync(IQuerySpecification<T> query = null, CancellationToken cancelToken = default,
            params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> predicated = _set;

            if (query != null && !(includes is null))
            {
                foreach (var inc in includes)
                {
                    predicated.Include(inc);
                }
            }
            else if (query != null)
            {
                predicated = _set.AsNoTracking().Where(query.Predicates.Single());
                if (query.Skip > 0 && query.Take > 0)
                    predicated = predicated.Skip(query.Skip).Take(query.Take);
                if (!(query.OrderBy is null) || !(query.OrderByDescending is null))
                {
                    IOrderedQueryable<T> sortedQuery;
                    if (!(query.OrderBy is null))
                    {
                        sortedQuery = predicated.OrderBy(query.OrderBy);
                    }
                    else
                    {
                        sortedQuery = predicated.OrderByDescending(query.OrderByDescending);
                    }

                    if (!(query.ThenBy is null))
                        sortedQuery = sortedQuery.ThenBy(query.ThenBy);
                    else if(!(query.ThenByDescending is null))
                    {
                        sortedQuery = sortedQuery.ThenByDescending(query.ThenByDescending);
                    }

                    predicated = sortedQuery;
                }
            }
            else
            {
                return _set.ToListAsync(cancelToken);
            }

            return predicated.ToListAsync(cancelToken);
        }

        /// <summary>
        /// Allows for advanced queries with a single include
        /// </summary>
        /// <param name="q"></param>
        /// <param name="inlcude"></param>
        /// <param name="filters"></param>
        /// <returns>IQueryable<T></returns>
        public IQueryable<T> Query(IQuerySpecification<T> q, Expression<Func<T, object>> include)
        {
            IQueryable<T> query = _set;

            if (!(include is null))
            {
                query = query.Include(include);
            }


            if (q is null)
            {
                return query;
            }

            foreach (var filter in q.Predicates)
            {
                query = query.Where(filter);
            }

            return query;
        }

        /// <summary>
        /// Allows for advanced queries with multiple inlcudes passed via a List<string>
        /// in the IncludeParams type.
        /// </summary>
        /// <param name="param"></param>
        /// <param name="filters"></param>
        /// <returns></returns>
        public IQueryable<T> Query(IncludeParams<T> param, IQuerySpecification<T> filters)
        {
            IQueryable<T> query = _set;

            if (param != null)
            {
                if (param.Includes.Count > 0)
                {
                    foreach (var include in param.Includes)
                    {
                        query.Include(include);
                    }
                }
                //previously a foreach loop
                query = filters.Predicates.Aggregate(query, (current, p) => current.Where(p));
            }

            return query;
        }

        public Task<T> FindBy(string id, CancellationToken cancelToken = default)
        {
            var result = _set.FindAsync(id);
            return result;
        }

        public Task<T> FindBy(int id, CancellationToken canelToken = default)
        {
            return _set.FindAsync(id);
        }

        /// <summary>
        /// Returns a task of a single entity when you need to filter by many predicates.
        /// Note that this finds one but it will be untracked by the context
        /// </summary>
        /// <param name="cancelToken"></param>
        /// <param name="predicates"></param>
        /// <returns>Task<T></returns>
        public Task<T> FindOne(CancellationToken cancelToken = default, params Expression<Func<T, bool>>[] predicates)
        {
            Task<T> result = null;
            foreach (var t in predicates)
            {
                result = _set.AsNoTracking().FirstOrDefaultAsync(t,cancelToken);
            }
            return result;
        }

        /// <summary>
        /// Returns a task of a single entity when you need to filter by many predicates.
        /// Note that this finds one but it will be tracked by the context
        /// </summary>
        /// <param name="cancelToken"></param>
        /// <param name="tracked"></param>
        /// <param name="predicates"></param>
        /// <returns>Task<T></returns>
        public Task<T> FindOne(CancellationToken cancelToken = default, bool tracked = true,
            params Expression<Func<T, bool>>[] predicates)
        {
            Task<T> result = null;
            if (tracked)
            {
                foreach (var predicate in predicates)
                {
                    result = _set.FirstOrDefaultAsync(predicate, cancelToken);
                } 
            }
            return result;
        }

        public bool Remove(string id)
        {
            var one = _set.Find(id);
            one.Delete();
            if (one.IsDeleted)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Remove(int id)
        {
            var one = _set.Find(id);
            one.Delete();
            if (one.IsDeleted)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Remove(T entity)
        {
            return false;
        }

        public void Add(T entity)
        {
            _set.Add(entity);
        }

        public void Update(T entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
        }

        public int Commit()
        {
            return _db.SaveChanges();
        }
    }
}
