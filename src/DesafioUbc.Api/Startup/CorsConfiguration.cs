using DesafioUbc.Application.Helper;

namespace DesafioUbc.Api.Startup;

public static class CorsConfiguration
{
    public static void AddCrossOrigin(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddCors(policy =>
        {
            policy.AddPolicy(Configuration.CorsPolicyName, builder => builder
                                                                      .AllowAnyOrigin()
                                                                      .AllowAnyHeader()
                                                                      .AllowAnyMethod());
        });
    }
}