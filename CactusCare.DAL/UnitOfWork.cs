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
        private IDoctorRepository _doctorRepository;

        public UnitOfWork(CactusCareContext context, IServiceProvider serviceProvider)
        {
            _context = context;
            _serviceProvider = serviceProvider;
        }

        public ISpecialityRepository SpecialityRepository => _specialityRepository ??= _serviceProvider.GetService<ISpecialityRepository>();

        public IDoctorRepository DoctorRepository => _doctorRepository ??= _serviceProvider.GetService<IDoctorRepository>();

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
