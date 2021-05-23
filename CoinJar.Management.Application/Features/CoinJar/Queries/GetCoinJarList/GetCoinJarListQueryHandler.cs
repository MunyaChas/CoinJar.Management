using AutoMapper;
using CoinJar.Management.Application.Contracts.Persistence;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CoinJar.Management.Application.Features.CoinJar
{
    public class GetCoinJarListQueryHandler : IRequestHandler<GetCoinJarListQuery, List<CoinDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepo<Coinjar.Management.Domain.Entities.Coin> _coinjarRepo;

        public GetCoinJarListQueryHandler(IMapper mapper, IAsyncRepo<Coinjar.Management.Domain.Entities.Coin> coinJarRepo)
        {
            _mapper = mapper;
            _coinjarRepo = coinJarRepo; 
        }
        public async Task<List<CoinDTO>> Handle(GetCoinJarListQuery request, CancellationToken cancellationToken)
        {
            var coinJarList = await _coinjarRepo.ListAllAsync();
            return _mapper.Map<List<CoinDTO>>(coinJarList);
        }
    }
}
