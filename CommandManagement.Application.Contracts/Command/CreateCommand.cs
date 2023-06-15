
namespace CommandManagement.Application.Contracts.Command
{
    public class CreateCommand
    {
        public int Id { get; set; }

        public string HowTo { get; set; }

        public string CommandLine { get; set; }

        public int PlatformId { get; set; }

    }
}
