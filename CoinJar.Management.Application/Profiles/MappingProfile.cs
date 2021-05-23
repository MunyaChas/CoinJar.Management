using AutoMapper;
using CoinJar.Management.Application.Features.CoinJar;
using CoinJar.Management.Application.Features.CoinJar.Commands.CreateCoinJar;

namespace CoinJar.Management.Application.Profiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Coinjar.Management.Domain.Entities.Coin, CoinDTO>().ReverseMap();
            CreateMap<CreateCoinVM, CoinDTO>().ReverseMap();
        }
    }
}
