using Klaro.Application.Common.Interfaces;
using Klaro.Infrastructure.Persistence;
using Klaro.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klaro.Infrastructure
{
    public static class DependencyInjection
    {
        /// <summary>
        /// Extension method for registering services in DI container
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // register db context
            services.AddDbContext<KlaroDbContext>(options => 
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"))
            );

            // register subscription repo
            services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();

            return services;
        }
    }
}
