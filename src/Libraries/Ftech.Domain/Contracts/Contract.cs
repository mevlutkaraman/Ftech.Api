using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ftech.Domain.Contracts
{
    public sealed class Contract : Entity
    {
        public string ContractNo { get; set; } = null!;
    }
}
