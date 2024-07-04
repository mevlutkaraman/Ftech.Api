namespace Ftech.Infrastructure.RabbitMQ.Abstract
{
    public interface IMQConfiguration
    {
        string HostName { get; }
        int Port { get; }
        string UserName { get; }
        string Password { get; }
        string Url { get; }
    }
}