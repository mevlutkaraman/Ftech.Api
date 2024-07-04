using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ftech.Infrastructure.RabbitMQ.Services
{
    public interface IPublisherLogger
    {
        void Log<T>(T model);//Parameters
    }
}
