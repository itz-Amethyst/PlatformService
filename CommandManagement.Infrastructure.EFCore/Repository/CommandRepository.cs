using _0_Framework.Infrastructure;
using CommandManagement.Application.Contracts.Command;
using CommandManagement.Domain.Commands;
using CommandManagement.Infrastructure.EFCore.Context;

namespace CommandManagement.Infrastructure.EFCore.Repository
{
    public class CommandRepository : RepositoryBase<int, Command>, ICommandRepository
    {
        private readonly CommandContext _commandContext;
        // It works like the same method GetById but for this section i used this
        public CommandRepository(CommandContext commandContext) : base(commandContext)
        {
            _commandContext = commandContext;
        }

        public IEnumerable<Command> GetCommandsForPlatform(int platformId)
        {
            return _commandContext.Commands
                .Where(x => x.PlatformId == platformId)
                .OrderByDescending(x=>x.Id);
        }

        public Command GetCommand(int platformId, int commandId)
        {
            return _commandContext.Commands
                .Where(x => x.PlatformId == platformId && x.Id == commandId)
                .FirstOrDefault();
        }

        //? This should be in application layer
        public void CreateCommand(int platformId, CreateCommand command)
        {
            if(command == null) throw new ArgumentNullException(nameof(command));

            command.PlatformId = platformId;

            var commandData = new Command(command.Id, command.HowTo, command.CommandLine, command.PlatformId);

            _commandContext.Add(commandData);

            _commandContext.SaveChanges();
        }

    }
}
