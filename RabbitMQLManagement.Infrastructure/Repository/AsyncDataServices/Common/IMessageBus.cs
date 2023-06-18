using RabbitMQ.Client;

namespace RabbitMQLManagement.Infrastructure.Services.Repository.AsyncDataServices.Common
{
    public interface IMessageBus
    {
        void Dispose();

        void RabbitMQ_ConnectionShutDown(object sender, ShutdownEventArgs e);
    }
}
