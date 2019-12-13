using CactusCare.Abstractions;
using CactusCare.Abstractions.Repositories;
using CactusCare.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using CactusCare.Abstractions.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace CactusCare.DAL
{
    public class ConfigureDAL : IConfigureLayer
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
                serviceProvider.GetRequiredService<CactusCareContext>().Database.Migrate();

            if (development)
                serviceProvider.Seed();
        }
    }
}
