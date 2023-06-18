using _0_Framework.Application.EventProcessing;
using CommandManagement.Domain.Commands;
using CommandManagement.Infrastructure.EFCore.Context;
using CommandManagement.Infrastructure.EFCore.Repository;
using CommandManagement.Infrastructure.EventProcessing.EventProcessing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CommandManagement.Infrastructure.Configuration
{
    public class CommandManagementBootstrapper
    {
        public static void Configure(IServiceCollection services)
        {

            #region Repository

            services.AddTransient<ICommandRepository , CommandRepository>();

            #endregion

            #region EventProcessor

            services.AddSingleton<IEventProcessor, EventProcessor>();

            #endregion


            //if (environment.IsProduction())
            //{
            //    Console.WriteLine("--> Using SqlServer Db <--");
            //    services.AddDbContext<PlatformContext>(x => x.UseSqlServer(connectionString));
            //}
            //else
            //{
            //    Console.WriteLine("--> Using InMem Db <--");
            //    services.AddDbContext<PlatformContext>(x => x.UseInMemoryDatabase("InMem"));

            //}

            services.AddDbContext<CommandContext>(x => x.UseInMemoryDatabase("InMem"));

        }
    }
}