using CommandManagement.Domain.Commands;

namespace CommandManagement.Domain
{
    public interface ICommandRepository
    {
        //? Because its external i didn't create it as generic in Repository Framework 
        // Commands
        IEnumerable<Command> GetCommandsForPlatform(int platformId);

        Command GetCommand(int platformId , int commandId);

        void CreateCommand(int id);
    }
}
