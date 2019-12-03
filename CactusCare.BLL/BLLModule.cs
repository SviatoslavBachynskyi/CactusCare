﻿using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Autofac;
using AutoMapper;
using CactusCare.Abstractions.Services;
using CactusCare.BLL.Mapping;
using CactusCare.BLL.Services;
using Microsoft.Extensions.Configuration;
using Module = Autofac.Module;

namespace CactusCare.BLL
{
    public class BLLModule : Module
    {
        private readonly IConfigurationRoot _configuration;

        public BLLModule(IConfigurationRoot configuration)
        {
            this._configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            //configure all services
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces()
                .InstancePerRequest();

            //Configure AutoMapper
            builder.RegisterInstance(new MapperConfiguration
            ((cfg) =>
            {
                cfg.AddProfile(new SpecialityProfile());
                cfg.AddProfile(new HospitalProfile());
                cfg.AddProfile(new DoctorProfile());
            }).CreateMapper());
        }
    }
}
