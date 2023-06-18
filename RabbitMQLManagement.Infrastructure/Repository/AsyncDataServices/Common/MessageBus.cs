using RabbitMQ.Client;
using System.Threading.Channels;

namespace RabbitMQLManagement.Infrastructure.Services.Repository.AsyncDataServices.Common
{
    public class MessageBus : IMessageBus
    {
        private readonly IModel _channel;
        private readonly IConnection _connection;

        public MessageBus(IModel channel, IConnection connection)
        {
            _channel = channel;
            _connection = connection;
        }

        public void Dispose()
        {
            Console.WriteLine($"--> Message Bus Disposed");

            if (_channel.IsOpen)
            {
                _channel.Close();
                _connection.Close();
            }
        }

        public void RabbitMQ_ConnectionShutDown(object sender, ShutdownEventArgs e)
        {
            Console.WriteLine($"--> RabbitMQ Connection Shutdown");
        }
    }
}
