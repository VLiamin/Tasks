using Microsoft.EntityFrameworkCore;
using System;

namespace InternetStore
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          //  modelBuilder.ApplyConfigurationsFromAssembly();
        }
    }
}