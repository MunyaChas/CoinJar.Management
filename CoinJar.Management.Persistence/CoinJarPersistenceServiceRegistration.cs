using CoinJar.Management.Application.Contracts.Persistence;
using CoinJar.Management.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CoinJar.Management.Persistence
{
    public static class CoinJarPersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CoinJarDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("CoinJarConnectionString")));
            services.AddScoped(typeof(IAsyncRepo<>), typeof(BaseRepository<>));
            services.AddScoped<ICoinJar, CoinRepository>();
            return services;
        }
    }
}
