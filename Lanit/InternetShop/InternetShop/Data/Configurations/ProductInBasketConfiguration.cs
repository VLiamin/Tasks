using InternetShop.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InternetShop.Data.Configurations
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
