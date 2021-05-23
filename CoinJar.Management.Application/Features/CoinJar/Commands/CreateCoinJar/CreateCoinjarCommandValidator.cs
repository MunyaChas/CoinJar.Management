using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoinJar.Management.Application.Features.CoinJar.Commands.CreateCoinJar
{
    public class CreateCoinjarCommandValidator : AbstractValidator<CreateCoinJarCommand>
    {
        public CreateCoinjarCommandValidator()
        {
            RuleFor(x => x.Amount).NotEmpty().WithMessage("{PropertName} is required.").GreaterThan(0);
            //RuleFor(x => x.Volume).NotEmpty().WithMessage("{PropertName} is required.").GreaterThan(0);
        }
    }
}
