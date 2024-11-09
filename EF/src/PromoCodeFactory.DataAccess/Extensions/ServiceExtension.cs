using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
namespace PromoCodeFactory.DataAccess.Extensions;
public static class ServiceExtension
{
    public static IServiceCollection AddPromoCodesDbContext(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlite(connectionString);
            options.UseSnakeCaseNamingConvention();
        });
        return services;
    }
}
