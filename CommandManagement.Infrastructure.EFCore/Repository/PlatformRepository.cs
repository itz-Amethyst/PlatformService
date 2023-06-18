using _0_Framework.Infrastructure;
using CommandManagement.Domain.Platforms;
using CommandManagement.Infrastructure.EFCore.Context;
using Microsoft.EntityFrameworkCore;

namespace CommandManagement.Infrastructure.EFCore.Repository
{
    public class PlatformRepository : RepositoryBase<int , Platform> , IPlatformRepository
    {
        private readonly CommandContext _commandContext;
        public PlatformRepository(CommandContext commandContext) : base(commandContext)
        {
            _commandContext = commandContext;
        }
    }
}
