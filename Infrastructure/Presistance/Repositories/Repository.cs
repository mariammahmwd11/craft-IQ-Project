
using Application.Common;
using Application.Interfaces;
using Ardalis.Specification.EntityFrameworkCore;
using Infrastructure.Presistance.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Infrastructure.Presistance.Repositories
{
    public class Repository<T>: RepositoryBase<T>,Application.Interfaces.IRepository<T>
        where T : class
    {
        private readonly AppDbContext _context;
      
        public Repository(AppDbContext context):base(context)
        {
           _context = context;
          
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

       

        //replace the following methods with the above methods using specification pattern
        /*   public async Task Add(T entity)
           {
               await set.AddAsync(entity);
           }
           public void Delete(T entity)
           {
               set.Remove(entity);
           }
           public void Update(T entity)
           {
               set.Update(entity);
           }
           public async Task<T> GetByFilter(Expression<Func<T, bool>> filter = null, bool tracking = true, params Expression<Func<T, object>>[] includes)
           {
               IQueryable<T> query = set;

               if (!tracking)
               {
                   query = query.AsNoTracking();
               }

               if (filter != null)
               {
                   query = query.Where(filter);
               }

               if (includes != null && includes.Length > 0)
               {
                   foreach (var include in includes)
                   {
                       query = query.Include(include);
                   }
               }

               return await query.FirstOrDefaultAsync();
           }

           public async Task<PagedResult<T>> GetAll(int pagenumber = 1, int pagesize = 10, Expression<Func<T, bool>> filter = null, bool tracking = true,
               Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null, params Expression<Func<T, object>>[] includes)
           {
               IQueryable<T> query = set;


               if (!tracking)
               {
                   query = query.AsNoTracking();
               }

               if (filter != null)
               {
                   query = query.Where(filter);
               }

               var totalcount = await query.CountAsync();

               if (includes != null && includes.Length > 0)
               {
                   foreach (var include in includes)
                   {
                       query = query.Include(include);
                   }
               }

               if (orderby != null)
               {
                   query = orderby(query);
               }

               if (pagenumber < 1) pagenumber = 1;
               if (pagesize > 50) pagesize = 50;

               var items = await query.Skip((pagenumber - 1) * pagesize)
                   .Take(pagesize).ToListAsync();

               var result = new PagedResult<T>
               {
                   Items = items,
                   PageNumber = pagenumber,
                   PageSize = pagesize,
                   TotalItems = totalcount,
               };

               return result;

           }*/


    }
}
