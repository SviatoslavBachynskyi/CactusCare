using CactusCare.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using CactusCare.DAL;

namespace CactusCare.BLL
{
    public class ConfigureBLL : IConfigureLayer
    {
        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            new ConfigureDAL().ConfigureServices(services, configuration);
        }
    }
}
