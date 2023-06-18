using System.ComponentModel.DataAnnotations;
using CommandManagement.Domain.Commands;

namespace CommandManagement.Domain.Platforms
{
    public class Platform
    {
        //? In here i use DataAnnotations you can use custom mappings either

        [Key]
        [Required]
        public int Id { get; private set; }

        [Required]
        public int ExternalId { get; private set; }

        [Required]
        public string Name { get; private set; }

        public ICollection<Command> Commands { get; private set; } = new List<Command>();

        //public Platform(int id, int externalId, string name)
        //{
        //    Id = id;
        //    ExternalId = externalId;
        //    Name = name;
        //}
    }
}