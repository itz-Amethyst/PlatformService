using CommandManagement.Domain.Commands;
using CommandManagement.Domain.Platforms;
using Microsoft.EntityFrameworkCore;

namespace CommandManagement.Infrastructure.EFCore.Context
{
    public class CommandContext: DbContext
    {
        public DbSet<Platform> Platforms { get; set; }

        public DbSet<Command> Commands { get; set; }

        public CommandContext(DbContextOptions<CommandContext> options) : base(options)
        {
            
        }
    }
}