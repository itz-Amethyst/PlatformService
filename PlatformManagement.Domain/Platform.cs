using _0_Framework.Domain;
namespace PlatformManagement.Domain
{
    public class Platform : EntityBase
    {
        public string Name { get; private set; }

        public string Publisher { get; private set; }

        public string Cost { get; private set; }


        public Platform(string name, string publisher, string cost)
        {
            Name = name;
            Publisher = publisher;
            Cost = cost;
        }
    }
}