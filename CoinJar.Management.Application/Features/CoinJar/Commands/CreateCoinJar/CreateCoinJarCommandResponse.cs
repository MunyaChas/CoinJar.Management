using CoinJar.Management.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoinJar.Management.Application.Features.CoinJar.Commands.CreateCoinJar
{
    public class CreateCoinJarCommandResponse : BaseResponse
    {
        public CreateCoinJarCommandResponse() : base()
        {

        }

        public CoinDTO Coin { get; set; }
    }
}
