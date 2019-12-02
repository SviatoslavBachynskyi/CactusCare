using CactusCare.Abstractions;
using CactusCare.Abstractions.Repositories;
using CactusCare.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace CactusCare.DAL
{
    public class ConfigureDAL : IConfigureLayer
    {
        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CactusCareContext>(
                (options) => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            ConfigureRepositories(services, configuration);
            services.AddScoped<IUnitOfWork, UnitOfWork>();

        }

        public void Configure(IApplicationBuilder app, IServiceProvider serviceProvider, IWebHostEnvironment environment)
        {
            if (environment.IsDevelopment())
            {
                serviceProvider.GetRequiredService<CactusCareContext>().Database.Migrate();
            }
        }

        private void ConfigureRepositories(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ISpecialityRepository, SpecialityRepository>();
            services.AddScoped<IHospitalRepository, HospitalRepository>();
            services.AddScoped<IDoctorRepository, DoctorRepository>();
            services.AddScoped<IReviewRepository, ReviewRepository>();
        }
    }
}
