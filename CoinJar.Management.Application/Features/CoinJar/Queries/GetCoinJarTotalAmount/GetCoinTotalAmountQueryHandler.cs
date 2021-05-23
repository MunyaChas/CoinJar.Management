using AutoMapper;
using CoinJar.Management.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CoinJar.Management.Application.Features.CoinJar.Queries.GetCoinJarTotalAmount
{
    public class GetCoinTotalAmountQueryHandler : IRequestHandler<GetCoinTotalAmountQuery, CoinTotalVm>
    {
        //private readonly IMapper _mapper;
        private readonly ICoinJar _coinjarRepo;
        public GetCoinTotalAmountQueryHandler(ICoinJar coinJarRepo)
        {
            _coinjarRepo = coinJarRepo;
        }
        public async Task<CoinTotalVm> Handle(GetCoinTotalAmountQuery request, CancellationToken cancellationToken)
        {
            var coinTotals = await _coinjarRepo.GetTotalAmount();

            return new CoinTotalVm { TotalCoinAmount = coinTotals.Item1, TotalCoinVolume = coinTotals.Item2};
        }
    }
}
