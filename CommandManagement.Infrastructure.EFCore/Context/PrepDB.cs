using CommandManagement.Domain.Commands;
using CommandManagement.Domain.Platforms;
using CommandManagement.Infrastructure.Services.SyncDataService.Grpc;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace CommandManagement.Infrastructure.EFCore.Context
{
    public static class PrepDB
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var grpcClient = serviceScope.ServiceProvider.GetService<IPlatformDataClient>();

                var platforms = grpcClient.ReturnAllPlatforms();

                SeedData(serviceScope.ServiceProvider.GetService<IPlatformRepository>() , platforms);
            }
        }

        private static void SeedData(IPlatformRepository platformRepository , IEnumerable<Platform> platforms)
        {
            Console.WriteLine($"--> Seeding new platforms...");

            foreach (var plat in platforms)
            {
                if (!platformRepository.Exists(x => x.ExternalId == plat.ExternalId))
                {
                    platformRepository.Create(plat);
                    platformRepository.SaveChanges();
                }
            }
        }
    }
}
