namespace Ftech.Infrastructure.RabbitMQ.Services
{
    public interface IPublisherService
    {
        void SendQueue<T>(T model, string queueName, IPublisherLogger? logger = null) where T: class, new();
        void PublishExchange<T>(T model, string exchangeName, string exchangeType, IPublisherLogger? logger = null) where T : class, new();
    }
}