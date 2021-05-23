using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoinJar.Management.Application.Features.CoinJar.Commands.CreateCoinJar
{
    public class CreateCoinJarCommand : IRequest<CreateCoinJarCommandResponse>
    {
        public decimal Amount { get; set; }
    }
}
