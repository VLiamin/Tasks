using InternetShop.Data.Configurations;
using InternetShop.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace InternetShop.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ProductInBasket> ProductsInBasket { get; set; }
        public String ProjectId { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(OrderConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductInBasket).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
