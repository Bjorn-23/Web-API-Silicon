using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Web_API_Silicon.Configurations;

public static class JwtConfiguration
{
    /// <summary>
    /// Configures the JSON Web Token to be sent out for the user to be able to acces certain parts of the Api. 
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    public static void RegisterJwt(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication( x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme; // Sets default authentication scheme
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme; // Sets default challenge scheme

        }).AddJwtBearer(x =>
            {
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = configuration["Jwt:Issuer"], // Sets which URLs are OK to send JWT from.

                    ValidateAudience = true,
                    ValidAudience = configuration["Jwt:Audience"], // Sets which URLs are OK to be sent a JWT.

                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Secret"]!)), // The key used to create the JWT.

                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.FromSeconds(5) // Allows clocks in different systems to be off by 5 seconds.
                };
            });
    }
}
