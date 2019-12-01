using CactusCare.Abstractions;
using CactusCare.Abstractions.Repositories;
using CactusCare.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CactusCare.DAL
{
    public class ConfigureDAL : IConfigureLayer
    {
        //TODO add automatic migrations
        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CactusCareContext>(
                (options) => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            ConfigureRepositories(services, configuration);
            services.AddScoped<IUnitOfWork, UnitOfWork>();

        }

        internal void ConfigureRepositories(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ISpecialityRepository, SpecialityRepository>();
        }
    }
}
