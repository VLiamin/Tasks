using Homework5.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homework5.Data.Configuration
{
    public class ProductInBasketConfiguration : IEntityTypeConfiguration<ProductInBasket>
    {
        public void Configure(EntityTypeBuilder<ProductInBasket> builder)
        {
            builder.ToTable("ProductsInBacket");
            builder.Property(x => x.ProductId).IsRequired();
            builder.Property(x => x.UserId).IsRequired();
            builder.Property(x => x.Count).IsRequired();
        }
    }
}
