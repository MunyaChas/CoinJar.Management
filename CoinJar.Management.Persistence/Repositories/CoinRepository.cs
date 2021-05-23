using Coinjar.Management.Domain.Entities;
using CoinJar.Management.Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CoinJar.Management.Persistence.Repositories
{
    public class CoinRepository : BaseRepository<Coin>, ICoinJar
    {
        public CoinRepository(CoinJarDbContext coinJarDbContext): base(coinJarDbContext)
        {
            
        }

        public async Task AddCoin(ICoin coin)
        {
            var checkCoinHasBeenAdded = await _coinJarDbContext.Coins.FirstOrDefaultAsync();
            if(checkCoinHasBeenAdded != null)
            {
                checkCoinHasBeenAdded.Amount = +coin.Amount;
                checkCoinHasBeenAdded.Volume = +coin.Volume;
                await UpdateAsync(checkCoinHasBeenAdded);
            }
            else
            {
                await AddAsync(new Coin { Amount = coin.Amount, Volume = coin.Volume });
            }
        }
        public async Task Reset()
        {
            var resetCoin = await _coinJarDbContext.Coins.FirstOrDefaultAsync();
            if (resetCoin != null)
            {
                resetCoin.Amount = 0M;
                resetCoin.Volume = 0M;
                await UpdateAsync(resetCoin);
            }
        }

        public async Task<Tuple<decimal, decimal>> GetTotalAmount()
        {
            var coins = await _coinJarDbContext.Coins.FirstOrDefaultAsync();
            var result = coins == null ? new Tuple<decimal, decimal>(0, 0) : new Tuple<decimal, decimal>(coins.Amount, coins.Volume);
            return result;
        }
    }
}
