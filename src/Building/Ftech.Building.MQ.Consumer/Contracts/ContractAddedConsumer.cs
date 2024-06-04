using Ftech.Infrastructure.MQ.RabbitMQ.Services;
using Ftech.Infrastructure.RabbitMQ.Services;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ftech.Building.MQ.Consumer.Contracts
{
    public class ContractAddedConsumer : BackgroundService
    {
        private readonly IConsumerService _consumerService;

        public ContractAddedConsumer(IConsumerService consumerService)
        {
           _consumerService = consumerService;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var key = "test";
            _consumerService.StartConsumer(key, Process, new ContractConsumerLogger());

            return Task.CompletedTask;
        }

        private static void Process(string message)
        {
            //Logic
        }

        class ContractConsumerLogger : IConsumerLogger
        {
            public void Log()
            {
                //Db log 
            }
        }
    }
}
