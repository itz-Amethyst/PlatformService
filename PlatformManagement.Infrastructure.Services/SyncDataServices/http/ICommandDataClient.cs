using PlatformManagement.Application.Contracts.Platform;

namespace PlatformManagement.Infrastructure.Services.SyncDataServices.http
{
    public interface ICommandDataClient
    {
        Task SendPlatformToCommand(PlatformViewModel command);
    }
}
