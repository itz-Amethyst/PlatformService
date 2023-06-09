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

            builder.Property(x => x.Publisher).IsRequired();
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Cost).IsRequired();
        }
    }
}
