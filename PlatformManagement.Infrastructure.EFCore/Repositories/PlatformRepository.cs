using _0_Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;
using PlatformManagement.Application.Contracts.Platform;
using PlatformManagement.Domain;
using PlatformManagement.Infrastructure.EFCore.Context;

namespace PlatformManagement.Infrastructure.EFCore.Repositories
{
    public class PlatformRepository : Repository<int, Platform>, IPlatformRepository
    {

        private readonly PlatformContext _context;

        public PlatformRepository(PlatformContext context) : base(context)
        {
            _context = context;
        }

        public void CreatePlatform(CreatePlatform command)
        {
            if(command == null) throw new ArgumentNullException(nameof(command));

            var platform = new Platform(command.Name, command.Publisher, command.Cost);

            _context.Platforms.Add(platform);
        }
    }
}
