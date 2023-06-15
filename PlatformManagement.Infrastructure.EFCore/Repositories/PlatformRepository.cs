using _0_Framework.Infrastructure;
using PlatformManagement.Application.Contracts.Platform;
using PlatformManagement.Domain;
using PlatformManagement.Infrastructure.EFCore.Context;

namespace PlatformManagement.Infrastructure.EFCore.Repositories
{
    public class PlatformRepository : RepositoryBase<int, Platform>, IPlatformRepository
    {

        private readonly PlatformContext _context;

        public PlatformRepository(PlatformContext context) : base(context)
        {
            _context = context;
        }

        public void CreatePlatform(CreatePlatform command)
        {

            //? It should be in application layer
            if(command == null) throw new ArgumentNullException(nameof(command));

            var platform = new Platform(command.Name, command.Publisher, command.Cost);

            _context.Platforms.Add(platform);

            _context.SaveChanges();
        }
    }
}
