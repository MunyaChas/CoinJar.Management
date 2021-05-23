using System;

namespace Coinjar.Management.Domain.Entities
{
    public class Coin
    {
        public Guid Id { get; set; }

        public decimal Amount { get; set; }
        public decimal Volume { get; set; }
    }
}
