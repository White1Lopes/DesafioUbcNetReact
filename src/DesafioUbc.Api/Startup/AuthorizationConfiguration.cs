using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace DesafioUbc.Api.Startup;

public static class AuthorizationConfiguration
{
    public static void AddAuthorizationConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
               .AddJwtBearer(options =>
               {
                   options.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateIssuer = false,
                       ValidateAudience = false,
                       ValidateLifetime = true,
                       ValidateIssuerSigningKey = true,
                       ValidIssuer = configuration["Jwt:Issuer"],
                       ValidAudience = configuration["Jwt:Audience"],
                       IssuerSigningKey =
                           new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!))
                   };
               });
        services.AddAuthorization();
    }
}