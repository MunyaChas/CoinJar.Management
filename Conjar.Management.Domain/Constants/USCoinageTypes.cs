using System.ComponentModel;

namespace Coinjar.Management.Domain.Constants
{
    public enum USCoinageTypes
    {
        [Description("1c - Penny")]
        Penny = 1,
        [Description("5c - Nickel")]
        Nickel = 5,
        [Description("10c - Dime")]
        Dime = 10,
        [Description("25c - Quarter")]
        Quarter = 25,
        [Description("50c - Half Dollar")]
        Half_Dollar = 50,
        [Description("$1 - Large Dollar")]
        Large_Dollar = 100
    }
}
