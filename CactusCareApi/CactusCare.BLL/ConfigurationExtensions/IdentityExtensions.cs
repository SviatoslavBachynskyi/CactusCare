using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using CactusCare.Abstractions.Entities;
using CactusCare.BLL.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace CactusCare.BLL.ConfigurationExtensions
{
    internal static class IdentityExtensions
    {
        internal static IServiceCollection ConfigureIdentity(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IUserClaimsPrincipalFactory<User>, ClaimsPrincipalFactory>();
            services.AddSingleton<JwtTokenGenerator>();

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

            return services;
        }
    }
}
