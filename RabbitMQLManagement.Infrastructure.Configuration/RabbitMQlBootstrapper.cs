using Microsoft.Extensions.DependencyInjection;
using RabbitMQLManagement.Domain;
using RabbitMQLManagement.Infrastructure.Services.Repository.AsyncDataServices;

namespace RabbitMQLManagement.Infrastructure.Configuration
{
    public class RabbitMQlBootstrapper
    {
        public static void Configure(IServiceCollection services)
        {
            #region RabbitMqlService

            services.AddSingleton<IMessageBusClient, MessageBusClient>();

            #endregion

        }
    }
}