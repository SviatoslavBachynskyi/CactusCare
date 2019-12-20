using CactusCare.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using CactusCare.Abstractions.Entities;
using Microsoft.AspNetCore.Identity;
using CactusCare.DAL.ConfigurationExtensions;

namespace CactusCare.DAL
{
    public class ConfigureDal : IConfigureLayer
    {
        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CactusCareContext>(
                (options) => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services
            .AddIdentity<User, IdentityRole>()
            .AddEntityFrameworkStores<CactusCareContext>()
            .AddDefaultTokenProviders();
        }

        public void Configure(IServiceProvider serviceProvider, bool development)
        {
            if (development)
            {
                serviceProvider.GetRequiredService<CactusCareContext>().Database.Migrate();
            }

            serviceProvider.SeedEssentialData();
            if (development)
            {
                serviceProvider.SeedTestData();
            }
        }
    }
}
