using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PlatformManagement.Domain;

namespace PlatformManagement.Infrastructure.EFCore.Context
{
    public static class PrepDB
    {
        public static void PrepPopulation(IApplicationBuilder app, bool isProduction)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<PlatformContext>() , isProduction);
            }
        }

        private static void SeedData(PlatformContext context , bool isProduction)
        {
            if (isProduction)
            {
                Console.WriteLine("--> Attending to Apply Migrations <--");
                try
                {
                    context.Database.Migrate();
                }
                catch (Exception e)
                {
                    Console.WriteLine($"--> Could not run migrations: {e.Message} <--");
                    throw;
                }
            }


            if (!context.Platforms.Any())
            {
                Console.WriteLine("--> Seeding Data <--");

                context.Platforms.AddRange(
                    new Platform("Dot Net", "Microsoft", "Free"),
                        new Platform("React", "Facebook", "Free"),
                        new Platform("Kubernetes" , "Cloud Native Computing Foundation" , "Free")
                    );

                context.SaveChanges();
            }

            else
            {
                Console.WriteLine("--> We already have data <--");
            }
        }
    }
}
