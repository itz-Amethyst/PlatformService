using CommandManagement.Domain.Platforms;

namespace CommandManagement.Infrastructure.Services.SyncDataService.Grpc
{
    public interface IPlatformDataClient
    {
        IEnumerable<Platform> ReturnAllPlatforms();
    }
}
