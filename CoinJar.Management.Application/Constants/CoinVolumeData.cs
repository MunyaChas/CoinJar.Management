using Coinjar.Management.Domain.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoinJar.Management.Application.Constants
{
    public static class CoinVolumeData
    {
        public static readonly decimal MAX_VOLUME = 42M;
        public static Dictionary<USCoinageTypes, decimal> CoinVolumeMapping = new Dictionary<USCoinageTypes, decimal>()
        {
            { USCoinageTypes.Penny, 0.1052M },
            { USCoinageTypes.Nickel, 0.1691M },
            { USCoinageTypes.Dime, 0.0767M },
            { USCoinageTypes.Quarter, 0.1917M },
            { USCoinageTypes.Half_Dollar, 0.3835M },
            { USCoinageTypes.Large_Dollar, 0.7669M }
        };
    }
}
