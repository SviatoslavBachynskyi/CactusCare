using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Builder;

namespace CactusCare.Abstractions
{
    public interface IConfigureLayer
    {
        void ConfigureServices(IServiceCollection services, IConfiguration configuration);

        void Configure(IServiceProvider serviceProvider, bool development);
    }
}
