using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoinJar.Management.Application.Features.CoinJar.Queries.GetCoinJarTotalAmount
{
    public class GetCoinTotalAmountQuery : IRequest<CoinTotalVm>
    {
    }
}
