using CoinJar.Management.Application.Contracts.Persistence;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CoinJar.Management.Application.Features.CoinJar.Queries.ResetCoinJar
{
    public class ResetCoinQueryHandler : IRequestHandler<ResetCoinQuery>
    {
        private readonly ICoinJar _coinjarRepo;
        private readonly ILogger<ResetCoinQueryHandler> _logger;
        public ResetCoinQueryHandler(ICoinJar coinJarRepo, ILogger<ResetCoinQueryHandler> logger)
        {
            _coinjarRepo = coinJarRepo;
            _logger = logger;
        }
        public async Task<Unit> Handle(ResetCoinQuery request, CancellationToken cancellationToken)
        {
            try
            {
                await _coinjarRepo.Reset();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Coin Reset failed due to an error : {ex.Message}");
            }
            
            return Unit.Value;
        }
    }
}
