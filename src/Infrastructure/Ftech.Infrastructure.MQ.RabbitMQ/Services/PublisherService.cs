using System.Text;
using Ftech.Infrastructure.RabbitMQ.Abstract;
using Ftech.Infrastructure.RabbitMQ.Concrete;
using RabbitMQ.Client;

namespace Ftech.Infrastructure.RabbitMQ.Services
{
    public sealed class PublisherService : IPublisherService, IDisposable
    {
        private readonly IMQService _rabbitMQServices;
        private readonly IObjectConvertFormat _objectConvertFormat;
        private IModel _channel;
        private IConnection _connection;

        public PublisherService(IMQService rabbitMqServices, IObjectConvertFormat objectConvertFormat)
        {
            _rabbitMQServices = rabbitMqServices;
            _objectConvertFormat = objectConvertFormat;
        }

        public void PublishExchange<T>(T model, string exchangeName, string exchangeType, IPublisherLogger? logger = null) where T : class, new()
        {
            try
            {
                _connection = _rabbitMQServices.GetConnection();
                using (_channel = _rabbitMQServices.GetModel(_connection))
                {
                    _channel.ExchangeDeclare(exchangeName, exchangeType, true, false, null);
                    var properties = _channel.CreateBasicProperties();
                    properties.Persistent = true;
                    properties.Expiration = MQDefaults.MessagesTTL.ToString();

                    var body = Encoding.UTF8.GetBytes(_objectConvertFormat.ObjectToJson(model));
                    _channel.BasicPublish(exchange: exchangeName,
                        routingKey: string.Empty,
                        mandatory: false,
                        basicProperties: properties,
                        body: body);

                    if (logger is not null)
                        logger.Log(model);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException?.Message.ToString());
            }
        }

        public void SendQueue<T>(T model, string queueName, IPublisherLogger? logger = null) where T : class, new()
        {
            try
            {
                _connection = _rabbitMQServices.GetConnection();
                using (_channel = _rabbitMQServices.GetModel(_connection))
                {
                    _channel.QueueDeclare(queue: queueName, durable: true, exclusive: false, autoDelete: false, arguments: null);
                    var properties = _channel.CreateBasicProperties();
                    properties.Persistent = true;
                    properties.Expiration = MQDefaults.MessagesTTL.ToString();

                    var body = Encoding.UTF8.GetBytes(_objectConvertFormat.ObjectToJson(model));
                    _channel.BasicPublish(exchange: string.Empty,
                        routingKey: queueName,
                        mandatory: false,
                        basicProperties: properties,
                        body: body);

                    if (logger is not null)
                        logger.Log(model);
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