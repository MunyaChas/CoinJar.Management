using Coinjar.Management.Domain.Entities;
using CoinJar.Management.Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CoinJar.Management.Persistence.Repositories
{
    public class BaseRepository<T> : IAsyncRepo<T> where T : class
    {
        protected readonly CoinJarDbContext _coinJarDbContext;

        public BaseRepository(CoinJarDbContext coinJarDbContext)
        {
            _coinJarDbContext = coinJarDbContext;
        }
        public async Task<T> AddAsync(T entity)
        {
            await _coinJarDbContext.Set<T>().AddAsync(entity);
            await _coinJarDbContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            _coinJarDbContext.Set<T>().Remove(entity);
            await _coinJarDbContext.SaveChangesAsync();
        }

        public async Task<T> GetById(Guid id) => await _coinJarDbContext.Set<T>().FindAsync(id);

        public async Task<T> GetFindAny() => await _coinJarDbContext.Set<T>().FirstOrDefaultAsync();

        public async Task<IReadOnlyList<T>> ListAllAsync() => await _coinJarDbContext.Set<T>().ToListAsync(); 

        public async Task UpdateAsync(T entity)
        {
            _coinJarDbContext.Entry(entity).State = EntityState.Modified;
            await _coinJarDbContext.SaveChangesAsync();
        }

    }
}
