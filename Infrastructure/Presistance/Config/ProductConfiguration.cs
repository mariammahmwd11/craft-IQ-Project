using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CraftIQ.Infrastructure.Presistance.Config
{
    public class ProductConfiguration : IEntityTypeConfiguration<Domain.Entites.Product>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Domain.Entites.Product> builder)
        {
            builder.Property(p => p.ID)
                    .ValueGeneratedOnAdd();

            builder.Property(p => p.ProductId)
                    .IsRequired();

            builder.Property(p => p.Name)
                   .HasMaxLength(50);

            builder.Property(p => p.Description)
                   .HasMaxLength(200);
        }

    }
}
