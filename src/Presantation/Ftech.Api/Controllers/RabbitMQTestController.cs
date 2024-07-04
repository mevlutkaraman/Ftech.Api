using Ftech.Domain.Contracts;
using Ftech.Services.Contracts;
using Microsoft.AspNetCore.Mvc;


namespace Ftech.Api.Controllers
{
    [Route("[controller]")]
    public class RabbitMQTestController : ControllerBase
    {
        private readonly IContractService _contractService;
        public RabbitMQTestController(IContractService contractService)
        {
                _contractService = contractService;
        }

        [HttpPost]
        public async Task<string> Publish()
        {
            var contract = new Contract { ContractNo = Guid.NewGuid().ToString() };
            await _contractService.AddContractAsync(contract);

            return "rabbitmq publish";
        }
    }
}
