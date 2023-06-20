using _0_Framework.Application.EventProcessing;
using CommandManagement.Domain.Commands;
using CommandManagement.Domain.Platforms;
using CommandManagement.Infrastructure.EFCore.Context;
using CommandManagement.Infrastructure.EFCore.Repository;
using CommandManagement.Infrastructure.EventProcessing.EventProcessing;
using CommandManagement.Infrastructure.Services.SyncDataService.Grpc;
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
            services.AddTransient<IPlatformRepository, PlatformRepository>();

            #endregion

            #region EventProcessor

            services.AddSingleton<IEventProcessor, EventProcessor>();

            #endregion

            #region Grpc

            services.AddScoped<IPlatformDataClient, PlatformDataClient>();

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