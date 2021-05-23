using CoinJar.Management.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoinJar.Management.Application.Features.CoinJar.Commands.CreateCoinJar
{
    public class CreateCoinVM : ICoin
    {
        public decimal Amount { get; set; }
        public decimal Volume { get; set; }
    }
}
