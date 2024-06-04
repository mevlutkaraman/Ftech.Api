using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ftech.Domain.Contracts.Events
{
    public sealed class ContractDeletedDomainEvent : INotification
    {
        public Contract Contract { get; private set; }
        public ContractDeletedDomainEvent(Contract contract)
        {
            Contract = contract;
        }
    }
}
