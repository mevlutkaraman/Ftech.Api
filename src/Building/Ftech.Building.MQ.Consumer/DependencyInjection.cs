using Ftech.Building.MQ.Consumer.Contracts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ftech.Building.MQ.Consumer
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddConsumers(this IServiceCollection services)
        {
            services.AddHostedService<ContractAddedConsumer>();
            services.AddHostedService<ContractDeletedConsumer>();
            services.AddHostedService<ContractUpdatedConsumer>();

            return services;
        }
    }
}
