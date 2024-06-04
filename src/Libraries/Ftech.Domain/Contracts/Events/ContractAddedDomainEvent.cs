using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ftech.Domain.Contracts.Events
{
    public sealed class ContractAddedDomainEvent: INotification
    {
        public Contract Contract { get; private set; }

        public ContractAddedDomainEvent(Contract contract)
        {
            Contract = contract;        
        }
    }
}
