using CraftIQ.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CraftIQ.Infrastructure.Presistance.Config
{
    public class inventoryConfiguration : IEntityTypeConfiguration<Inventory>
    {
        public void Configure(EntityTypeBuilder<Inventory> builder)
        {
            builder.Property(p => p.ID)
                   .ValueGeneratedOnAdd();

            builder.Property(p => p.Location)
                   .HasMaxLength(200);

            builder.Property(p => p.Name)
                   .HasMaxLength(50);
        }
    }
}
