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

namespace CactusCare.BLL
{
    public class ConfigureBLL : IConfigureLayer
    {
        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            new ConfigureDAL().ConfigureServices(services, configuration);

            ConfigureBLLServives(services, configuration);
            ConfigureMapper(services, configuration);
        }

        private void ConfigureBLLServives(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ISpecialityService, SpecialityService>();
            services.AddScoped<IHospitalService, HospitalService>();
            services.AddScoped<IDoctorService, DoctorService>();
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
                    }).CreateMapper()
                );
        }
    }
}
