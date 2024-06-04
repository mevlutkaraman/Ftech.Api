using System.ComponentModel;

namespace Ftech.Infrastructure.RabbitMQ.Concrete
{
    public class MQDefaults
    {
        public static int MessagesTTL { get; set; } = 1000 * 60 * 60 * 2;
    }
}