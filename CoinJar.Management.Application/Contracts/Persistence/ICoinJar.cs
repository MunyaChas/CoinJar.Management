
using System;
using System.Threading.Tasks;

namespace CoinJar.Management.Application.Contracts.Persistence
{
    public interface ICoinJar : IAsyncRepo<Coinjar.Management.Domain.Entities.Coin>
    {
       Task AddCoin(ICoin coin);
        Task<Tuple<decimal, decimal>> GetTotalAmount();
        Task Reset();
    }
}
