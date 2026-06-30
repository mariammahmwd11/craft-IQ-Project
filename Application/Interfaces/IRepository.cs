using Application.Common;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Application.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task Add(T entity);
        Task<T> GetByFilter(Expression<Func<T, bool>> filter = null, bool tracking = true, params Expression<Func<T, object>>[] includes);
        Task<PagedResult<T>> GetAll(int pagenumber = 1, int pagesize = 10 ,Expression<Func<T, bool>> filter = null, bool tracking = true, Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null,
            params Expression<Func<T, object>>[] includes);
        void Delete(T entity);
        void Update(T entity);
    }
}
