using Ftech.Domain.Contracts.Events;
using Ftech.Infrastructure.RabbitMQ.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ftech.Application.Contracts.EventHandlers
{
    public sealed class SendMQWhenContractAddedEventHandler : INotificationHandler<ContractAddedDomainEvent>
    {
        private readonly IPublisherService _publisherService;
        public SendMQWhenContractAddedEventHandler(IPublisherService publisherService)
        {
            _publisherService = publisherService;       
        }

        public async Task Handle(ContractAddedDomainEvent notification, CancellationToken cancellationToken)
        {
            var model = notification.Contract;
            string key = "test";
            _publisherService.SendQueue(model, key, new ContractPublisherLogger());
        }
    }

    class ContractPublisherLogger : IPublisherLogger
    {
        public void Log()
        {
            //Db log 
        }
    }
}
