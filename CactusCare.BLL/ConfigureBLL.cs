using CactusCare.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using CactusCare.DAL;
using AutoMapper;
using CactusCare.BLL.Mapping;
using CactusCare.Abstractions.Services;
using CactusCare.BLL.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace CactusCare.BLL
{
    public class ConfigureBLL : IConfigureLayer
    {
        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            new ConfigureDAL().ConfigureServices(services, configuration);

            ConfigureBLLServices(services, configuration);
            ConfigureMapper(services, configuration);
        }

        public void Configure(IApplicationBuilder app, IServiceProvider serviceProvider,
            IWebHostEnvironment environment)
        {
            new ConfigureDAL().Configure(app, serviceProvider, environment);
        }


        private void ConfigureBLLServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ISpecialityService, SpecialityService>();
            services.AddScoped<IHospitalService, HospitalService>();
            services.AddScoped<IDoctorService, DoctorService>();
            services.AddScoped<IReviewService, ReviewService>();
        }

        private void ConfigureMapper(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(
                new MapperConfiguration
                ((cfg) =>
                {
                    cfg.AddProfile(new SpecialityProfile());
                    cfg.AddProfile(new HospitalProfile());
                    cfg.AddProfile(new DoctorProfile());
                    cfg.AddProfile(new ReviewProfile());
                }).CreateMapper()
            );
        }
    }
}