using Ftech.Infrastructure.MQ.RabbitMQ.Services;
using Ftech.Infrastructure.RabbitMQ.Abstract;
using Ftech.Infrastructure.RabbitMQ.Concrete;
using Ftech.Infrastructure.RabbitMQ.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Ftech.Infrastructure.MQ.RabbitMQ
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRabbitMQ(this IServiceCollection services)
        {
            services.AddScoped<IMQService, MQService>();
            services.AddScoped<IObjectConvertFormat, ObjectConvertFormat>();
            services.AddScoped<IPublisherService, PublisherService>();
            services.AddScoped<IConsumerService, ConsumerService>();
            services.AddScoped<IMQConfiguration, MQConfiguration>();

            return services;
        }
    }
}
