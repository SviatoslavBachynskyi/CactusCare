using System;
using System.Collections.Generic;
using Autofac;
using Autofac.Core;
using CactusCare.Abstractions;
using CactusCare.API;
using CactusCare.Api.ConfigurationExtensions;
using CactusCare.API.ConfigurationExtensions;
using CactusCare.BLL;
using CactusCare.DAL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CactusCare.Api
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        private readonly IWebHostEnvironment _environment;

        private readonly List<IModule> _modules;

        private readonly List<IConfigureLayer> _layerConfigurations;

        public Startup(IWebHostEnvironment environment, IConfiguration configuration)
        {
            this._configuration = configuration;
            this._environment = environment;
            
            this._modules = new List<IModule>()
            {
                new DalModule(),
                new BllModule()
            };

            this._layerConfigurations = new List<IConfigureLayer>()
            {
                new ConfigureDal(),
                new ConfigureBll()
            };
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();

            services.AddControllers().AddXmlSerializerFormatters();

            services.ConfigureCors(this._configuration);

            services.ConfigureSwagger();

            foreach (var layerConfiguration in _layerConfigurations)
            {
                layerConfiguration.ConfigureServices(services, _configuration);
            }
        }

        // this method register modules for each layer
        public void ConfigureContainer(ContainerBuilder builder)
        {
            foreach (var module in this._modules)
            {
                builder.RegisterModule(module);
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IServiceProvider serviceProvider)
        {
            app.UseConfiguredSwagger();

            app.UseConfiguredCors();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseExceptionMiddleware();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
            
            foreach (var layerConfiguration in _layerConfigurations)
            {
                layerConfiguration.Configure(serviceProvider, _environment.IsDevelopment());
            }
        }
    }
}