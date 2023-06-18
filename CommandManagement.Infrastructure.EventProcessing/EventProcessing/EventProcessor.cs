using System.Text.Json;
using _0_Framework.Application.EventProcessing;
using AutoMapper;
using CommandManagement.Domain.Commands;
using CommandManagement.Domain.Platforms;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQLManagement.Application.Contracts;

namespace CommandManagement.Infrastructure.EventProcessing.EventProcessing
{
    public class EventProcessor : IEventProcessor
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly IMapper _mapper;

        public EventProcessor(IServiceScopeFactory scopeFactory, IMapper mapper)
        {
            _scopeFactory = scopeFactory;
            _mapper = mapper;
        }

        public void ProcessEvent(string message)
        {
            var eventType = DetermineEvent(message);

            switch (eventType)
            {
                case EventType.PlatformPublished:
                   AddPlatform(message);
                    break;
                default:
                    Console.WriteLine();
                    break;
            }
        }

        private EventType DetermineEvent(string notificationMessage)
        {
            Console.WriteLine("--> Determining Event");

            var eventType = JsonSerializer.Deserialize<GenericEventViewModel>(notificationMessage);

            switch (eventType.Event)
            {
                case "Platform_Published":
                    Console.WriteLine("--> Platform Published Event Detected");
                    return EventType.PlatformPublished;
                default:
                    Console.WriteLine("--> Could not determine the event type");
                    return EventType.Undetermined;
            }
        }

        private void AddPlatform(string platformPublishedMessage)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var repo = scope.ServiceProvider.GetRequiredService<IPlatformRepository>();

                var platformPublishedViewModel =
                    JsonSerializer.Deserialize<PlatformPublishedViewModel>(platformPublishedMessage);

                try
                {

                    Platform plat = _mapper.Map<Platform>(platformPublishedViewModel);
                    //? Check later
                    if (!repo.Exists(x => x.ExternalId == plat.ExternalId))
                    {
                        repo.Create(plat);
                        Console.WriteLine("--> Platform Added!");
                    }

                    else
                    {
                        Console.WriteLine("--> Platform already exists ...");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"--> Could not Add platform to DB: {e.Message}");
                }
            }
        }
    }
}
