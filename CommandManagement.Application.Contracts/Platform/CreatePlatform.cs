
namespace CommandManagement.Application.Contracts.Platform
{
    public class CreatePlatform
    {
        public int Id { get; set; }

        public int ExternalId { get; set; }

        public string Name { get; set; }

        public ICollection<Command> Commands { get; set; } 
    }
}
