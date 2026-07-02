using CraftIQ.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CraftIQ.Infrastructure.Presistance.Config
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(p => p.ID)
                     .ValueGeneratedOnAdd();

            builder.Property(p => p.CategoryId)
                    .IsRequired();

            builder.Property(p => p.Name)
                   .HasMaxLength(50);

            builder.Property(p => p.Description)
                   .HasMaxLength(200);
        }
    }
}
