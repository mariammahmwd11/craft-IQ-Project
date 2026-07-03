
using Application.Common;
using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Application.Interfaces
{
    public interface IRepository<T>:IRepositoryBase<T> where T : class
    {


        Task SaveChangesAsync();






        //replace the following methods with the above methods using specification pattern


        /* Task Add(T entity);
       
        void Delete(T entity);
        void Update(T entity);
        Task<T> FirstOrDefultAsync(ISpecification<T> spc);
        Task<List<T>> ListAsync(ISpecification<T> spc);
        Task<int> CountAsync(ISpecification<T> spc);
        */

        //Task<T> GetByFilter(Expression<Func<T, bool>> filter = null, bool tracking = true, params Expression<Func<T, object>>[] includes);
        //Task<PagedResult<T>> GetAll(int pagenumber = 1, int pagesize = 10 ,Expression<Func<T, bool>> filter = null, bool tracking = true, Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null,
        //    params Expression<Func<T, object>>[] includes);
    }
}
