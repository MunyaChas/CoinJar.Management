using Coinjar.Management.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoinJar.Management.Application.Contracts.Persistence
{
    public interface IAsyncRepo<T> where T : class
    {
        Task<T> GetById(Guid id);
        Task<T> GetFindAny();
        Task<T> AddAsync(T entity);
        Task<IReadOnlyList<T>> ListAllAsync();
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
