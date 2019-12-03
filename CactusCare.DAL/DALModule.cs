using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Autofac;
using CactusCare.Abstractions;
using CactusCare.Abstractions.Repositories;
using CactusCare.DAL.Repositories;
using Microsoft.Extensions.Configuration;
using Module = Autofac.Module;

namespace CactusCare.DAL
{
    public class DALModule : Module
    {
        private IConfigurationRoot _configuration;

        public DALModule(IConfigurationRoot configuration)
        {
            this._configuration = configuration;
        }
        protected override void Load(ContainerBuilder builder)
        {
            //register all repositories
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces();

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
        }
    }
}
