using Ardalis.Specification;
using CraftIQ.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace CraftIQ_Project.Application.Features.Orders.Specification
{
    public class OrderByIdSpecification:SingleResultSpecification<Order>
    {
        public OrderByIdSpecification(Guid ORDERID)
        {
            Query.Where(x=>x.OrderId==ORDERID)
                .Include(x => x.orderDetails);



        }
    }
}
