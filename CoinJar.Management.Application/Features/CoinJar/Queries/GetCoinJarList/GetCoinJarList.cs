using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoinJar.Management.Application.Features.CoinJar
{
    public class GetCoinJarList : IRequest<List<CoinDTO>>
    {
    }
}
