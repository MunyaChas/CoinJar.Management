using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace CoinJar.Management.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection serviceDescriptors)
        {
            serviceDescriptors.AddAutoMapper(Assembly.GetExecutingAssembly());
            serviceDescriptors.AddMediatR(Assembly.GetExecutingAssembly());
            return serviceDescriptors;
        }
    }
}
