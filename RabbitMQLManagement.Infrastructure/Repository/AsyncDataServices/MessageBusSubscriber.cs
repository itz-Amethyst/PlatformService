using System.Text;
using _0_Framework.Application.EventProcessing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace RabbitMQLManagement.Infrastructure.Services.Repository.AsyncDataServices
{
    public class MessageBusSubscriber : BackgroundService
    {
        private readonly IConfiguration _configuration;
        private readonly IEventProcessor _eventProcessor;
        private IConnection _connection;
        private IModel _channel;
        private string _queueName;

        public MessageBusSubscriber(IConfiguration configuration, IEventProcessor eventProcessor)
        {
            _configuration = configuration;
            _eventProcessor = eventProcessor;
            InitializeRabbitMq();
        }

        private void InitializeRabbitMq()
        {
            var factory = new ConnectionFactory()
            {
                HostName = _configuration.GetSection("RabbitMQHost").Value,
                Port = int.Parse(_configuration.GetSection("RabbitMQPort").Value)
            };
            _connection = factory.CreateConnection();

            _channel = _connection.CreateModel();

            _channel.ExchangeDeclare(exchange: "trigger" , type: ExchangeType.Fanout);

            _queueName = _channel.QueueDeclare().QueueName;

            _channel.QueueBind(queue: _queueName , exchange:"trigger" , routingKey: "");

            Console.WriteLine("--> Listening on the messageBus ... ");

            _connection.ConnectionShutdown += RabbitMQ_ConnectionShutdown;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
           stoppingToken.ThrowIfCancellationRequested();

           var consumer = new EventingBasicConsumer(_channel);

           consumer.Received += (ModuleHandle, ea) =>
           {
               Console.WriteLine("--> Event Received!");

               var body = ea.Body;

               var notificationMessage = Encoding.UTF8.GetString(body.ToArray());

               _eventProcessor.ProcessEvent(notificationMessage);
           };

           _channel.BasicConsume(queue: _queueName, autoAck: true, consumer: consumer);

           return Task.CompletedTask;
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
