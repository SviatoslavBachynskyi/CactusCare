﻿using CactusCare.Abstractions;
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
    public class ConfigureDal : IConfigureLayer
    {
        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CactusCareContext>(
                (options) => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            #region Identity
            services
            .AddIdentity<User, IdentityRole>()
            .AddEntityFrameworkStores<CactusCareContext>()
            .AddDefaultTokenProviders();

            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            services
                .AddAuthentication((options) =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(cfg =>
                {
                    cfg.RequireHttpsMetadata = false;
                    cfg.SaveToken = true;
                    var jwtConfig = configuration.GetSection("Jwt");
                    cfg.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidIssuer = jwtConfig["Issuer"],
                        ValidAudience = jwtConfig["Issuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig["Key"])),
                        ClockSkew = TimeSpan.Zero
                    };
                });

            services.Configure<IdentityOptions>((options) => { configuration.GetSection("IdentityOptions").Bind(options); });
            #endregion
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
