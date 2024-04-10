namespace Web_API_Silicon.Configurations;

public static class CorsConfiguration
{
    /// <summary>
    /// Configures Cors.
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    public static void RegisterCors(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddCors(x =>
        {
            x.AddPolicy("CustomOriginPolicy", policy =>
            {
                policy.WithOrigins("https://localhost:7088")
                .AllowAnyHeader()
                .AllowAnyMethod();
            });
            x.AddPolicy("InternalPolicy", policy =>
            {
                policy.WithOrigins("https://localhost:7034")
                .AllowAnyHeader()
                .AllowAnyMethod();
            });
        });
    }
}
