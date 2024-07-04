using Ftech.Services.Contracts;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Ftech.Services
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddMediatR(cf => cf.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

            services.AddScoped<IContractService, ContractService>();
            return services;
        }
    }
}
