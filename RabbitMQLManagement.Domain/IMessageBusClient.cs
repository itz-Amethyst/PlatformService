using RabbitMQLManagement.Application.Contracts;

namespace RabbitMQLManagement.Domain
{
    public interface IMessageBusClient
    {
        void PublishNewPlatform(PlatformPublishedViewModel platformPublishedViewModel);
    }
}