using MediatR;
using System;
using System.Collections.Generic;

namespace CoinJar.Management.Application.Features.CoinJar
{
    public class GetCoinJarListQuery : IRequest<List<CoinDTO>>
    {
        public Guid Id { get; set; }
    }
}
