using Ardalis.Specification;
using CraftIQ.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace CraftIQ_Project.Application.Features.Orders.Specification
{
    public class AllOrdersSpecification:Specification<Order>
    {
        public AllOrdersSpecification()
        {
            Query
              .Include(o => o.orderDetails)
              .OrderByDescending(o => o.OrderDate);

        }
    }
}
