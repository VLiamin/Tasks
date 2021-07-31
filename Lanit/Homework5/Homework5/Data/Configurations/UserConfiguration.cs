using Homework5.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homework5.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.Property(x => x.Name).HasMaxLength(16).IsRequired();
            builder.Property(x => x.Surname).HasMaxLength(16).IsRequired();
            builder.Property(x => x.Age).IsRequired();
        }
    }
}
