using Ftech.Domain.Contracts;

namespace Ftech.Services.Contracts
{
    public interface IContractService
    {
        public Task AddContractAsync(Contract contract);
        public Task DeleteContractAsync(Contract contract);
        public Task UpdateContractAsync(Contract contract);
    }
}
