using System;
using System.Collections.Generic;
using System.Text;
using CactusCare.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.IdentityModel.Tokens.Jwt;
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
        }

        public void Configure(IServiceProvider serviceProvider, bool development)
        {
        }
    }
}
