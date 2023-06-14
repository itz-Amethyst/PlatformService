using CommandManagement.Domain.Platforms;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CommandManagement.Infrastructure.EFCore.Mappings
{
    public class PlatformMapping : IEntityTypeConfiguration<Platform>
    {
        public void Configure(EntityTypeBuilder<Platform> builder)
        {
            builder.HasMany(x => x.Commands)
                .WithOne(x => x.Platform!)
                .HasForeignKey(x => x.PlatformId);
        }
    }
}
