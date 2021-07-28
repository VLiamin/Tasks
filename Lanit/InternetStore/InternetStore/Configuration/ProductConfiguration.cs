using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InternetStore.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.Property(x => x.Author).HasMaxLength(16).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(16).IsRequired();
            builder.Property(x => x.Cost).IsRequired();
            builder.Property(x => x.Weight).HasMaxLength(16);
        }
    }
}