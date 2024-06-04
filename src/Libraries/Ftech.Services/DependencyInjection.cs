using Ftech.Services.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace Ftech.Services
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IContractService, ContractService>();

            return services;
        }
    }
}
