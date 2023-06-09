using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PlatformManagement.Domain;
using PlatformManagement.Infrastructure.EFCore.Context;
using PlatformManagement.Infrastructure.EFCore.Repositories;

namespace PlatformManagement.Infrastructure.Configuration
{
    public class PlatformManagementBootstrapper
    {
        public static void Configure(IServiceCollection services)
        {

            #region Repository

            services.AddTransient<IPlatformRepository, PlatformRepository>();

            #endregion

            services.AddDbContext<PlatformContext>(x=>x.UseInMemoryDatabase("InMem"));
        }
    }
}