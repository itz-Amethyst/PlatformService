using _0_Framework.Domain;
using PlatformManagement.Application.Contracts.Platform;

namespace PlatformManagement.Domain
{
    public interface IPlatformRepository : IRepository<int , Platform>
    {
        void CreatePlatform(CreatePlatform command);
    }
}
