using System;
using System.Collections.Generic;
using System.Text;

namespace CoinJar.Management.Application.Features.CoinJar.Queries.GetCoinJarTotalAmount
{
    public class CoinTotalVm
    {
        public decimal TotalCoinAmount { get; set; }
        public decimal TotalCoinVolume { get; set; }
        public decimal CurrentCoinJarVolume { 
            get 
            { 
                return 42M - TotalCoinVolume; 
            }
        }
        public decimal CoinJarMaxVolume
        {
            get
            {
                return 42M;
            }
        } 
    }
}
