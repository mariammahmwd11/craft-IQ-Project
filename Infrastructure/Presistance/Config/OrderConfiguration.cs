using CraftIQ.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CraftIQ.Infrastructure.Presistance.Config
{
    public class OrderConfiguration : IEntityTypeConfiguration<Domain.Entites.Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(p => p.ID)
                   .ValueGeneratedOnAdd();
        }
    }
    public class OrderDetailsConfiguration : IEntityTypeConfiguration<Domain.Entites.OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.Property(p => p.ID)
                   .ValueGeneratedOnAdd();
        }
    }


    }

