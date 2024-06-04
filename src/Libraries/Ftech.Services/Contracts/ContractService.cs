
using Ftech.Domain.Contracts;
using Ftech.Domain.Contracts.Events;
using MediatR;

namespace Ftech.Services.Contracts
{
    public sealed class ContractService : IContractService
    {
        private readonly IMediator _mediator;
        public ContractService(IMediator mediator)
        {
                _mediator = mediator;
        }

        public async Task AddContractAsync(Contract contract)
        {
           //Logic
            await _mediator.Publish(new ContractAddedDomainEvent(contract));
        }

        public async Task DeleteContractAsync(Contract contract)
        {
            //Logic
            await _mediator.Publish(new ContractDeletedDomainEvent(contract));
        }

        public async Task UpdateContractAsync(Contract contract)
        {
            //Logic
            await _mediator.Publish(new ContractDeletedDomainEvent(contract));
        }
    }
}
