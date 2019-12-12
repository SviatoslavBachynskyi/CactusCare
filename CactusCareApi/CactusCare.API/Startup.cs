using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Autofac;
using CactusCare.Abstractions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CactusCareApi
{
    public class Startup
    {
        private const string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        private readonly IConfigurationRoot _configuration;

        private readonly IWebHostEnvironment _environment;

        private readonly List<Assembly> _assemblies;

        private readonly List<IConfigureLayer> _layerConfigurations = new List<IConfigureLayer>();

        public Startup(IWebHostEnvironment environment)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(environment.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{environment.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            _configuration = builder.Build();
            _environment = environment;

            //Load assemblies
            _assemblies =
                Directory.EnumerateFiles(Directory.GetCurrentDirectory(),
                        $"{nameof(CactusCare)}.*.dll", SearchOption.AllDirectories)
                    .Where((filename) => !filename.EndsWith(Assembly.GetExecutingAssembly().GetName().Name+".dll"))
                    .Select(Assembly.LoadFrom)
                    .ToList();
            _assemblies.Add(Assembly.GetExecutingAssembly());

            //load configurations
            foreach (var assembly in _assemblies)
            {
                var configure = typeof(IConfigureLayer);
                var types = assembly.GetTypes().Where((t) => configure.IsAssignableFrom(t) && !t.IsAbstract);
                foreach (var type in types)
                {
                    _layerConfigurations.Add((IConfigureLayer)Activator.CreateInstance(type));
                }
            }
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                    builder =>
                    {
                        // This policy will change on Azure.
                        builder.WithOrigins(_configuration.GetSection("AllowedOrigins").ToString())
                            .AllowAnyOrigin()
                            .AllowAnyHeader();
                    });
            });

            foreach (var layerConfiguration in _layerConfigurations)
            {
                layerConfiguration.ConfigureServices(services, _configuration);
            }
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            foreach (var assembly in _assemblies)
            {
                builder.RegisterAssemblyModules(assembly);
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IServiceProvider serviceProvider)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "CactusCare API V1"); });

            app.UseCors(MyAllowSpecificOrigins);

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

            foreach (var layerConfiguration in _layerConfigurations)
            {
                layerConfiguration.Configure(serviceProvider, _environment.IsDevelopment());
            }
        }
    }
}