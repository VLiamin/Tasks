using InternetShop.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InternetShop.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.Property(x => x.Name).HasMaxLength(16).IsRequired();
            builder.Property(x => x.Author).HasMaxLength(16).IsRequired();
            builder.Property(x => x.Cost).IsRequired();
            builder.Property(x => x.Weight).IsRequired();
            builder.Property(x => x.NumberOfPages).IsRequired();
        }
    }
}
