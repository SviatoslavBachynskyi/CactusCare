using System;
using System.Collections.Generic;
using System.Text;
using CactusCare.DAL.DataSeeding;
using Microsoft.Extensions.DependencyInjection;

namespace CactusCare.DAL
{
    internal static class ServiceExtensions
    {
        public static IServiceProvider Seed(this IServiceProvider provider)
        {
            var context = provider.GetRequiredService<CactusCareContext>();

            DataSeeder.SeedAdditional(context);

            return provider;
        }
    }
}
