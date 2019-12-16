﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CactusCare.Abstractions.Entities;
using CactusCare.DAL.DataSeeding;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CactusCare.DAL
{
    internal static class ServiceExtensions
    {
        public static IServiceProvider SeedEssentialData(this IServiceProvider provider)
        {
            var context = provider.GetRequiredService<CactusCareContext>();
            var userManager = provider.GetRequiredService<UserManager<User>>();
            var roleManager = provider.GetRequiredService<RoleManager<IdentityRole>>();
            var configuration = provider.GetRequiredService<IConfiguration>();

            DataSeeder.SeedEssentialData(
                context,
                userManager,
                roleManager,
                configuration["AdminPassword"]);

            return provider;
        }
        public static IServiceProvider SeedTestData(this IServiceProvider provider)
        {
            var context = provider.GetRequiredService<CactusCareContext>();

            DataSeeder.SeedTestData(context);

            return provider;
        }
    }
}
