using Coinjar.Management.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoinJar.Management.Persistence.Configurations
{
    public class CoinConfiguration : IEntityTypeConfiguration<Coin>
    {
        public void Configure(EntityTypeBuilder<Coin> builder)
        {
            builder.Property(x => x.Amount).IsRequired();
            builder.Property(x => x.Volume).IsRequired();
            builder.Property(x => x.Id).HasDefaultValueSql("NEWID()").ValueGeneratedOnAdd().IsRequired();
        }
    }
}
