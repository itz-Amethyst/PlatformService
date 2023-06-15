using _0_Framework.Domain;
using CommandManagement.Application.Contracts.Command;

namespace CommandManagement.Domain.Commands
{
    public interface ICommandRepository : IRepository<int, Command>
    {
        //? Because its external i didn't create it as generic in Repository Framework 
        // Commands
        IEnumerable<Command> GetCommandsForPlatform(int platformId);

        Command GetCommand(int platformId, int commandId);

        void CreateCommand(int platformId, CreateCommand command);
    }
}
