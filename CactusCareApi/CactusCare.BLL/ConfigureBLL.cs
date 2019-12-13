using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using CactusCare.Abstractions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;


namespace CactusCare.BLL
{
    class ConfigureBLL : IConfigureLayer
    {
        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
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
        }

        public void Configure(IServiceProvider serviceProvider, bool development)
        {
        }
    }
}
