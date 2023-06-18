using System.Text;
using System.Text.Json;
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
            var message = JsonSerializer.Serialize(platformPublishedViewModel);

            if (_connection.IsOpen)
            {
                Console.WriteLine($"--> RabbitMQ Connection is Open and sending message ...");
                //TODO Send the message
                SendMessage(message);
            }
            else
            {
                Console.WriteLine($"--> RabbitMQ Connection is Closed");
            }
        }

        private void SendMessage(string message)
        {
            var body = Encoding.UTF8.GetBytes(message);

            _channel.BasicPublish(exchange: "trigger", routingKey: "", basicProperties: null, body: body);

            Console.WriteLine($"--> We have sent {message}");

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

        private void RabbitMQ_ConnectionShutdown(object sender, ShutdownEventArgs e)
        {
            Console.WriteLine($"--> RabbitMQ Connection Shutdown");
        }
    }
}