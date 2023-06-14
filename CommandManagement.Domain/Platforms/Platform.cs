namespace CommandManagement.Domain.Platforms
{
    public class Platform
    {
        public int Id { get; private set; }

        public int ExternalId { get; private set; }

        public string Name { get; private set; }

        public Platform(int id, int externalId, string name)
        {
            Id = id;
            ExternalId = externalId;
            Name = name;
        }
    }
}