using System;

namespace CoinJar.Management.Application.Features.CoinJar
{
    public class CoinDTO
    {
        public Guid Id { get; set; }
        public decimal Amount { get; set; }
        public decimal Volume { get; set; }
    }
}