using Coinjar.Management.Domain.Constants;
using System;

public class CoinJarAuditModel
{
    public Guid Id { get; set; }
    public Activity Activity { get; set; }
    public string CoinName { get; set; }
    public decimal Amount { get; set; }
    public decimal Volume { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime? DateModified { get; set; }
    public byte[] RowVersion { get; set; }
}