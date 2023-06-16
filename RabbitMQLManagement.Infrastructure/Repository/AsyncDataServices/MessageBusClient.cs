using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using RabbitMQLManagement.Application.Contracts;
using RabbitMQLManagement.Domain;

namespace RabbitMQLManagement.Infrastructure.Services.Repository.AsyncDataServices
{
    public class MessageBusClient : IMessageBusClient
    {

        private readonly IConfiguration _configuration;
        private readonly IConnection _connection;
        private readonly IModel _channel;

        public MessageBusClient(IConfiguration configuration)
        {
            _configuration = configuration;
            var factory = new ConnectionFactory()
            {
                //HostName = _configuration["RabbitMQHost"]
                HostName = _configuration.GetSection("RabbitMQHost").Value,
                Port = int.Parse(_configuration.GetSection("RabbitMQPort").Value)
            };

            try
            {
                _connection = factory.CreateConnection();
                _channel = _connection.CreateModel();

                _channel.ExchangeDeclare(exchange: "trigger" , type: ExchangeType.Fanout);

                _connection.ConnectionShutdown += RabbitMQ_ConnectionShutdown;

                Console.WriteLine($"--> Connected to Message");
            }
            catch (Exception e)
            {
                Console.WriteLine($"--> Could Not Connect to the Message Bus : {e.Message}");
                throw;
            }
        }

        public void PublishNewPlatform(PlatformPublishedViewModel platformPublishedViewModel)
        {
            throw new NotImplementedException();
        }

        private void RabbitMQ_ConnectionShutdown(object sender , ShutdownEventArgs e)
        {
            Console.WriteLine($"--> RabbitMQ Connection Shutdown");
        }
    }
}