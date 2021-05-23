using AutoMapper;
using Coinjar.Management.Domain.Constants;
using Coinjar.Management.Domain.Entities;
using CoinJar.Management.Application.Constants;
using CoinJar.Management.Application.Contracts.Persistence;
using CoinJar.Management.Application.Helpers;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CoinJar.Management.Application.Features.CoinJar.Commands.CreateCoinJar
{
    public class CreateCoinJarCommandHandler : IRequestHandler<CreateCoinJarCommand, CreateCoinJarCommandResponse>
    {
        private IMapper _mapper;
        private ICoinJar _coinJarRepo;
        private ILogger<CreateCoinJarCommandHandler> _logger;
        decimal volumeForCoin = 0M;
        const decimal maxvolumeForCoin = 42M;
        public CreateCoinJarCommandHandler(IMapper mapper, ICoinJar coinJarRepo, ILogger<CreateCoinJarCommandHandler> logger)
        {
            _mapper = mapper;
            _coinJarRepo = coinJarRepo;
            _logger = logger;
        }
        public async Task<CreateCoinJarCommandResponse> Handle(CreateCoinJarCommand request, CancellationToken cancellationToken)
        {
            int coinAmount = Convert.ToInt32(request.Amount);
            var createCoinJarCommandResponse = await ValidateAndCheckForErrors(request, new CreateCoinJarCommandResponse());
            if (!CoinVolumeData.CoinVolumeMapping.ContainsKey((USCoinageTypes)coinAmount))
            {
                var descriptions = new DescriptionAttributes<USCoinageTypes>().Descriptions.ToList();
                var coins = string.Join(", ", descriptions);
                createCoinJarCommandResponse.Success = false;
                createCoinJarCommandResponse.Message = $"Coin {request.Amount} we couldn't find it in list of coin dominations & Volume for {request.Amount} can't be found! Here are valid list of coins {coins}";
                return createCoinJarCommandResponse;
            }
            volumeForCoin = CoinVolumeData.CoinVolumeMapping[(USCoinageTypes)coinAmount];
            if(createCoinJarCommandResponse.Success)
                createCoinJarCommandResponse = await AddCoin(new CreateCoinVM { Amount = request.Amount, Volume = volumeForCoin }, createCoinJarCommandResponse);
            return createCoinJarCommandResponse;
        }

        private async Task<CreateCoinJarCommandResponse> AddCoin(CreateCoinVM request, CreateCoinJarCommandResponse createCoinJarCommandResponse)
        {
            try
            {
                var coin = await _coinJarRepo.GetFindAny();
                var checkJarVolumeCapacity = coin == null ? 0 : coin?.Volume + request.Volume;
                if(checkJarVolumeCapacity <= maxvolumeForCoin)
                {
                    await _coinJarRepo.AddCoin(request);
                    createCoinJarCommandResponse.Coin = _mapper.Map<CoinDTO>(request);
                    createCoinJarCommandResponse.Message = $"{(USCoinageTypes)request.Amount} was successfully added to the CoinJar";
                    return createCoinJarCommandResponse;
                }
                else
                {
                    createCoinJarCommandResponse.Success = false;
                    createCoinJarCommandResponse.Message = $"CoinJar is full please Reset";
                    return createCoinJarCommandResponse;
                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed adding coin: {ex.Message}");
            }
            createCoinJarCommandResponse.Success = false;
            createCoinJarCommandResponse.Message = "Failed adding coin please notify Administrator";
            return createCoinJarCommandResponse;
        }

        private static async Task<CreateCoinJarCommandResponse> ValidateAndCheckForErrors(CreateCoinJarCommand request, CreateCoinJarCommandResponse createCoinJarCommandResponse)
        {
            var validator = new CreateCoinjarCommandValidator();
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.Errors.Count > 0)
            {
                createCoinJarCommandResponse.Success = false;
                createCoinJarCommandResponse.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    createCoinJarCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }
            return createCoinJarCommandResponse;
        }
    }
}
