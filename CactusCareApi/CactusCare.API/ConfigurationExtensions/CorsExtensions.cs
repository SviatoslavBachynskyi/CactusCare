using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CactusCare.Api.ConfigurationExtensions
{
    internal static class CorsExtensions
    {
        internal static string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        internal static IServiceCollection ConfigureCors(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                    builder =>
                    {
                        // This policy will change on Azure.
                        builder.WithOrigins(configuration.GetSection("AllowedOrigins").ToString())
                            .AllowAnyOrigin()
                            .AllowAnyHeader();
                    });
            });

            return services;
        }

        internal static IApplicationBuilder UseConfiguredCors(this IApplicationBuilder app)
        {
            app.UseCors(MyAllowSpecificOrigins);

            return app;
        }
    }
}
