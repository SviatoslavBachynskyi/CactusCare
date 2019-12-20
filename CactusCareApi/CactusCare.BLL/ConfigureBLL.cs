using System;
using CactusCare.Abstractions;
using CactusCare.BLL.ConfigurationExtensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CactusCare.BLL
{
    public class ConfigureBll : IConfigureLayer
    {
        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigureIdentity(configuration);
        }

        public void Configure(IServiceProvider serviceProvider, bool development)
        {
        }
    }
}
