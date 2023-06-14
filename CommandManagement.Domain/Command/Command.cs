using CommandManagement.Domain.Platforms;

namespace CommandManagement.Domain.Command
{
    public class Command
    {
        public int Id { get; private set; }

        public string HowTo { get; private set; }

        public string CommandLine { get; private set; }

        public int PlatformId { get; private set; }

        public Platform Platform { get; private set; }

        public Command(int id, string howTo, string commandLine, int platformId, Platform platform)
        {
            Id = id;
            HowTo = howTo;
            CommandLine = commandLine;
            PlatformId = platformId;
            Platform = platform;
        }
    }
}
