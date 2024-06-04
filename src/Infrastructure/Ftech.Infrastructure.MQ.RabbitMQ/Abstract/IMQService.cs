using RabbitMQ.Client;

namespace Ftech.Infrastructure.RabbitMQ.Abstract
{
    public interface IMQService
    {
        IConnection GetConnection();
        IModel GetModel(IConnection connection);
    }
}