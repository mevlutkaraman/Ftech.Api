using Ftech.Infrastructure.MQ.RabbitMQ.Services;
using Ftech.Infrastructure.RabbitMQ.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ftech.Building.MQ.Consumer.Contracts
{
    public class ContractAddedConsumer : IHostedService
    {
        private Timer _timer;
        private readonly IServiceProvider _serviceProvider;

        public ContractAddedConsumer(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(DoWorkJob, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));
            return Task.CompletedTask;
        }
        private void DoWorkJob(object? data)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var consumerService = scope.ServiceProvider.GetRequiredService<IConsumerService>();
                var key = "ftech-api-finance-contract-added";
                consumerService.StartConsumer(key, DoWorkConsumer, new ContractConsumerLogger());
            }
        }

        private void DoWorkConsumer(string message)
        {
            Console.WriteLine(message);
        }


        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }


        class ContractConsumerLogger : IConsumerLogger
        {
            public void Log(string message)
            {
                Debug.WriteLine(message);
            }
        }
    }
}
