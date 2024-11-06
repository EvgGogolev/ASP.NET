using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PromoCodeFactory.DataAccess;
using PromoCodeFactory.DataAccess.Infrastructure.EntityFramework;

namespace PromoCodeFactory.WebHost.Extensions;

public static class HostMigrationExtension
{
    public static async Task MigrateDatabaseAsync (this IHost webHost)
    {
        using (var scope = webHost.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            using (var context = services.GetRequiredService<ApplicationDbContext>())
            {
                try
                {
                    await context.Database.EnsureDeletedAsync();
                    await context.Database.MigrateAsync();
                    
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }
    }
}
