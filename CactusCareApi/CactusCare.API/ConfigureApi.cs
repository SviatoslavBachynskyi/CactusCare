using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CactusCare.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace CactusCareApi
{
    public class ConfigureApi: IConfigureLayer
    {
        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddOptions();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CactusCare API", Version = "v1" });
            });
        }

        public void Configure(IServiceProvider serviceProvider, bool development)
        {
        }
    }
}
