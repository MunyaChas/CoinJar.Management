using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoinJar.Management.Persistence.Configurations
{
    public class CoinJarAuditModelConfiguration : IEntityTypeConfiguration<CoinJarAuditModel>
    {
        public void Configure(EntityTypeBuilder<CoinJarAuditModel> builder)
        {
            builder.Property(x => x.Id).HasDefaultValueSql("NEWID()").ValueGeneratedOnAdd().IsRequired();
            builder.Property(x => x.RowVersion).IsConcurrencyToken().IsRequired();
            builder.Property(x => x.CoinName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Amount).IsRequired();//.HasPrecision(2);
            builder.Property(x => x.Volume).IsRequired();//.HasPrecision(4);
            //builder.Property(x => x.DateCreated).IsRequired().HasDefaultValueSql("getdate()");
            //builder.Property(x => x.DateModified).HasDefaultValueSql("getdate()");
            builder.Property(x => x.Activity).IsRequired().HasMaxLength(50);
        }
    }
}
