using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Autofac;
using CactusCare.Abstractions;
using CactusCare.API;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore;

namespace CactusCare.Api
{
    public class Startup
    {
        private const string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        private readonly IConfiguration _configuration;

        private readonly IWebHostEnvironment _environment;

        private readonly List<Assembly> _assemblies;

        private readonly List<IConfigureLayer> _layerConfigurations = new List<IConfigureLayer>();

        public Startup(IWebHostEnvironment environment, IConfiguration configuration)
        {
            _configuration = configuration;
            _environment = environment;

            //Load assemblies
            _assemblies =
                Directory.EnumerateFiles(Directory.GetCurrentDirectory(),
                        $"{nameof(CactusCare)}.*.dll", SearchOption.AllDirectories)
                    .Where((filename) => !filename.EndsWith(Assembly.GetExecutingAssembly().GetName().Name + ".dll"))
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
            services.AddOptions();

            services.AddControllers().AddXmlSerializerFormatters();

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

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CactusCare API", Version = "v1" });

                #region Authorization with swagger
                c.AddSecurityDefinition("Bearer",
                    new OpenApiSecurityScheme
                    {
                        Description = @"JWT Authorization header using the Bearer scheme.
                      Enter 'Bearer and then your token in the text input below.
                                  Example: 'Bearer 12345abcdef'",
                        Name = "Authorization",
                        In = ParameterLocation.Header,
                        Type = SecuritySchemeType.ApiKey,
                        Scheme = "Bearer"
                    });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                     {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                },
                                Scheme = "oauth2",
                                Name = "Bearer",
                                In = ParameterLocation.Header,

                            },
                            new List<string>()
                        }
                    });
                #endregion
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