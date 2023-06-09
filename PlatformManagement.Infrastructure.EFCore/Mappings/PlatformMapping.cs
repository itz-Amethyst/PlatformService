using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PlatformManagement.Infrastructure.EFCore.Mappings
{
    public class PlatformMapping : IEntityTypeConfiguration<>
    {
        public void Configure(EntityTypeBuilder<> builder)
        {
            builder.ToTable("");

            builder.HasKey(x => x.);
        }
    }
}
