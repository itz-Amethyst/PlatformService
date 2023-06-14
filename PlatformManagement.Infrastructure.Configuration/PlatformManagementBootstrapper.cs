using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PlatformManagement.Domain;
using PlatformManagement.Infrastructure.EFCore.Context;
using PlatformManagement.Infrastructure.EFCore.Repositories;

namespace PlatformManagement.Infrastructure.Configuration
{
    public class PlatformManagementBootstrapper
    {

        public static void Configure(IServiceCollection services , IHostEnvironment environment , string connectionString)
        {

            #region Repository

            services.AddTransient<IPlatformRepository, PlatformRepository>();

            #endregion

            
            if (environment.IsProduction())
            {
                Console.WriteLine("--> Using SqlServer Db <--");
                services.AddDbContext<PlatformContext>(x => x.UseSqlServer(connectionString));
            }
            else
            {
                Console.WriteLine("--> Using InMem Db <--");
                services.AddDbContext<PlatformContext>(x => x.UseInMemoryDatabase("InMem"));

            }

        }
    }
}