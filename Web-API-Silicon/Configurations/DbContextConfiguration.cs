using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Web_API_Silicon.Configurations;

public static class DbContextConfiguration
{
    /// <summary>
    /// Configures DbContext.
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    public static void RegisterDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DataContext>(x =>
        {
            x.UseSqlServer(configuration.GetConnectionString("SqlServer"));
        });
    }
}
