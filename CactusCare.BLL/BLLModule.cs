﻿using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Autofac;
using AutoMapper;
using CactusCare.Abstractions.Entities;
using CactusCare.Abstractions.Services;
using CactusCare.BLL.Identity;
using CactusCare.BLL.Mapping;
using CactusCare.BLL.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Module = Autofac.Module;

namespace CactusCare.BLL
{
    public class BLLModule : Module
    {
        public BLLModule()
        {
        }

        protected override void Load(ContainerBuilder builder)
        {
            //configure all services
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            //Configure AutoMapper
            builder.RegisterInstance(new MapperConfiguration(cfg => { cfg.AddMaps(Assembly.GetExecutingAssembly()); })
                .CreateMapper());

            builder.RegisterType<ClaimsPrincipalFactory>()
                .As<IUserClaimsPrincipalFactory<User>>();
        }
    }
}