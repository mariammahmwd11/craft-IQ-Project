using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Common
{
    public class PagedResult<T>
    {
        public IEnumerable<T> Items { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalItems { get; set; }
        public int Totalpages => (int)Math.Ceiling((decimal)TotalItems / PageSize);


        public PagedResult<TResult> MapTo<TResult>(Func<T, TResult> mapFunc)
        {
            return new PagedResult<TResult>
            {
                Items = this.Items.Select(mapFunc).ToList(),
                PageNumber = this.PageNumber,
                PageSize = this.PageSize,
                TotalItems = this.TotalItems
            };
        }
    }
}
