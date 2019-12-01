using CactusCare.Abstractions;
using CactusCare.Abstractions.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace CactusCare.DAL
{
    internal class UnitOfWork : IUnitOfWork
    {
        private CactusCareContext _context;
        private IServiceProvider _serviceProvider;

        private ISpecialityRepository _specialityRepository;

        public UnitOfWork(CactusCareContext context, IServiceProvider serviceProvider)
        {
            _context = context;
            _serviceProvider = serviceProvider;
        }

        public ISpecialityRepository SpecialityRepository => _specialityRepository ??= _serviceProvider.GetService<ISpecialityRepository>();

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
