using RabbitMQLManagement.Application.Contracts;
using RabbitMQLManagement.Domain;

namespace RabbitMQLManagement.Infrastructure.Repository.AsyncDataServices
{
    public class MessageBusClient : IMessageBusClient
    {
        public void PublishNewPlatform(PlatformPublishedViewModel platformPublishedViewModel)
        {
            throw new NotImplementedException();
        }
    }
}