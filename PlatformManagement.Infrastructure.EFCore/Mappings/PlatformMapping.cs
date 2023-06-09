using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlatformManagement.Domain;

namespace PlatformManagement.Infrastructure.EFCore.Mappings
{
    public class PlatformMapping : IEntityTypeConfiguration<Platform>
    {

        public void Configure(EntityTypeBuilder<Platform> builder)
        {
            builder.ToTable("Platforms");

            builder.HasKey(x => x.Id);
        }
    }
}
