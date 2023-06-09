using Microsoft.EntityFrameworkCore;
using PlatformManagement.Domain;
using PlatformManagement.Infrastructure.EFCore.Mappings;

namespace PlatformManagement.Infrastructure.EFCore.Context
{
    public class PlatformContext : DbContext
    {
        public DbSet<Platform> Platforms { get; set; }


        public PlatformContext(DbContextOptions<PlatformContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(PlatformMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
