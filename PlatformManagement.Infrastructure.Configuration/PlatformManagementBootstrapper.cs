using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PlatformManagement.Infrastructure.EFCore.Context;

namespace PlatformManagement.Infrastructure.Configuration
{
    public class PlatformManagementBootstrapper
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddDbContext<PlatformContext>(x=>x.UseInMemoryDatabase("InMem"));
        }
    }
}