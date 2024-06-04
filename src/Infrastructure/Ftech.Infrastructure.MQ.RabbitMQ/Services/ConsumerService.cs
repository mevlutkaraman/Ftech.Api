using Ftech.Infrastructure.RabbitMQ.Abstract;
using Ftech.Infrastructure.RabbitMQ.Concrete;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Ftech.Infrastructure.MQ.RabbitMQ.Services
{
    public sealed class ConsumerService : IConsumerService, IDisposable
    {
        private readonly IMQService _rabbitMQServices;
        private readonly IObjectConvertFormat _objectConvertFormat;
        private IModel _channel;
        private IConnection _connection;

        public ConsumerService(IMQService rabbitMqServices, IObjectConvertFormat objectConvertFormat)
        {
            _rabbitMQServices = rabbitMqServices;
            _objectConvertFormat = objectConvertFormat;
        }

        public void StartConsumer(string queueName, Action<string> processMessage,IConsumerLogger? logger = null)
        {
            try
            {
                _connection = _rabbitMQServices.GetConnection();
                using (_channel = _rabbitMQServices.GetModel(_connection))
                {
                    _channel.QueueDeclare(queue: queueName, durable: true, exclusive: false, autoDelete: false, arguments: null);
                    var consumer = new EventingBasicConsumer(_channel);
                    consumer.Received += (model, ea) =>
                    {
                        var body = ea.Body.ToArray();
                        var message = Encoding.UTF8.GetString(body);
                        processMessage(message);
                       _channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
                    };

                    _channel.BasicConsume(queue: queueName,
                                         autoAck: false,
                                         consumer: consumer);

                    if (logger is not null)
                        logger.Log();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException?.Message.ToString());
            }
        }

        public void Dispose()
        {
            _channel?.Dispose();
            _connection?.Close();
            _connection?.Dispose();
        }
    }
}
