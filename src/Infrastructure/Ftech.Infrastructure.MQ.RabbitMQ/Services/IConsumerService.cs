using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ftech.Infrastructure.MQ.RabbitMQ.Services
{
    public interface IConsumerService
    {
        void StartConsumer(string queueName, Action<string> processMessage,IConsumerLogger? logger = null);
    }
}
