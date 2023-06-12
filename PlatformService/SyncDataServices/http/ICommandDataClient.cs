using PlatformManagement.Application.Contracts.Platform;

namespace PlatformService.SyncDataServices.http
{
    public interface ICommandDataClient
    {
        Task SendPlatformToCommand(PlatformViewModel command);
    }
}
