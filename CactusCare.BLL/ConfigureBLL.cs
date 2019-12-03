using System;
using System.Collections.Generic;
using System.Text;
using CactusCare.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CactusCare.BLL
{
    class ConfigureBLL : IConfigureLayer
    {
        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            
        }

        public void Configure(IServiceProvider serviceProvider, bool development)
        {
        }
    }
}
