using Coinjar.Management.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CoinJar.Management.Persistence
{
    public class CoinJarDbContext : DbContext
    {
        public CoinJarDbContext(DbContextOptions<CoinJarDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Coin> Coins { get; set; }
        public DbSet<CoinJarAuditModel> CoinJarAuditModels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CoinJarDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<CoinJarAuditModel>())
            {
                switch (entry.State)
                {
                    case EntityState.Detached:
                        break;
                    case EntityState.Unchanged:
                        break;
                    case EntityState.Deleted:
                        break;
                    case EntityState.Modified:
                        entry.Entity.DateModified = DateTime.Now;
                        break;
                    case EntityState.Added:
                        entry.Entity.DateCreated = DateTime.Now;
                        break;
                    default:
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
