using System;
using Ftech.Infrastructure.RabbitMQ.Abstract;
using Microsoft.Extensions.Configuration;

namespace Ftech.Infrastructure.RabbitMQ.Concrete
{
    public class MQConfiguration : IMQConfiguration
    {
        public IConfiguration Configuration { get; }
        public MQConfiguration(IConfiguration configuration) => Configuration = configuration;

        public string HostName => Configuration["MQ.RabbitMQ.Configuration.HostName"] 
                                  ?? throw new ArgumentNullException("MQ.RabbitMQ.Configuration.HostName");
        public int Port => Convert.ToInt32(Configuration["MQ.RabbitMQ.Configuration.Port"] 
                                  ?? throw new ArgumentNullException("MQ.RabbitMQ.Configuration.Post"));
        public string UserName => Configuration["MQ.RabbitMQ.Configuration.UserName"] 
                                  ?? throw new ArgumentNullException("MQ.RabbitMQ.Configuration.UserName");
        public string Password => Configuration["MQ.RabbitMQ.Configuration.Password"] 
                                  ?? throw new ArgumentNullException("MQ.RabbitMQ.Configuration.Password");
    }
}