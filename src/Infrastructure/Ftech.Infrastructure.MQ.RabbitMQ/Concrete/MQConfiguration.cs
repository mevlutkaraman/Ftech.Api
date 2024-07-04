using System;
using Ftech.Infrastructure.RabbitMQ.Abstract;
using Microsoft.Extensions.Configuration;

namespace Ftech.Infrastructure.RabbitMQ.Concrete
{
    public class MQConfiguration : IMQConfiguration
    {
        public IConfiguration Configuration { get; }
        public MQConfiguration(IConfiguration configuration) => Configuration = configuration;

        public string HostName => Configuration["MQRabbitMQConfigurationHostName"] 
                                  ?? throw new ArgumentNullException("MQ.RabbitMQ.Configuration.HostName");
        public int Port => Convert.ToInt32(Configuration["MQRabbitMQConfigurationPort"] 
                                  ?? throw new ArgumentNullException("MQ.RabbitMQ.Configuration.Post"));
        public string UserName => Configuration["MQRabbitMQConfigurationUserName"] 
                                  ?? throw new ArgumentNullException("MQ.RabbitMQ.Configuration.UserName");
        public string Password => Configuration["MQRabbitMQConfigurationPassword"] 
                                  ?? throw new ArgumentNullException("MQ.RabbitMQ.Configuration.Password");

        public string Url => Configuration["MQRabbitMQConfigurationUrl"]
                          ?? throw new ArgumentNullException("MQ.RabbitMQ.Configuration.Url");
    }
}