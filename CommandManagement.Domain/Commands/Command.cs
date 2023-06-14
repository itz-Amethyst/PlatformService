using CommandManagement.Domain.Platforms;
using System.ComponentModel.DataAnnotations;

namespace CommandManagement.Domain.Commands
{
    public class Command
    {
        [Key]
        [Required]
        public int Id { get; private set; }

        [Required]
        public string HowTo { get; private set; }

        [Required]
        public string CommandLine { get; private set; }

        [Required]
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
