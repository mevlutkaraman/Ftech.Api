using System.Net.Security;
using Ftech.Infrastructure.RabbitMQ.Abstract;
using RabbitMQ.Client;
using RabbitMQ.Client.Exceptions;

namespace Ftech.Infrastructure.RabbitMQ.Concrete
{
    public class MQService : IMQService
    {
        private readonly IMQConfiguration _rabbitMqConfiguration;
        public MQService(IMQConfiguration rabbitMqConfiguration)
        {
            _rabbitMqConfiguration = rabbitMqConfiguration ?? throw new ArgumentNullException(nameof(rabbitMqConfiguration));
        }

        public IConnection GetConnection()
        {
            try
            {
                var factory = new ConnectionFactory
                {
                    //HostName = _rabbitMqConfiguration.HostName,
                    //UserName = _rabbitMqConfiguration.UserName,
                    //Password = _rabbitMqConfiguration.Password,
                    //Port = _rabbitMqConfiguration.Port,
                    Uri = new Uri(_rabbitMqConfiguration.Url),
                    AutomaticRecoveryEnabled = true,
                    NetworkRecoveryInterval = TimeSpan.FromSeconds(10),
                    TopologyRecoveryEnabled = false,
                    Ssl = new SslOption
                    {
                        Enabled = true,
                        AcceptablePolicyErrors = SslPolicyErrors.RemoteCertificateNameMismatch | SslPolicyErrors.RemoteCertificateChainErrors
                    }
                };

                return factory.CreateConnection();
            }
            catch (BrokerUnreachableException)
            {
                Thread.Sleep(5000);
                return GetConnection();
            }
        }

        public IModel GetModel(IConnection connection)
        {
            return connection.CreateModel();
        }
    }
}