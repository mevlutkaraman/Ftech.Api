using Ftech.Domain.Contracts.Events;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ftech.Application.Contracts.EventHandlers
{
    public sealed class SendMQWhenContractDeletedEventHandler : INotificationHandler<ContractDeletedDomainEvent>
    {
        public Task Handle(ContractDeletedDomainEvent notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
