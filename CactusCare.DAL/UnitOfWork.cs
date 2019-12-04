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
        private readonly CactusCareContext _context;
        private readonly IServiceProvider _serviceProvider;

        private ISpecialityRepository _specialityRepository;
        private IHospitalRepository _hospitalRepository;
        private IDoctorRepository _doctorRepository;
        private IReviewRepository _reviewRepository;

        public UnitOfWork(CactusCareContext context, IServiceProvider serviceProvider)
        {
            _context = context;
            _serviceProvider = serviceProvider;
        }

        public ISpecialityRepository SpecialityRepository =>
            _specialityRepository ??= _serviceProvider.GetService<ISpecialityRepository>();

        public IHospitalRepository HospitalRepository =>
            _hospitalRepository ??= _serviceProvider.GetService<IHospitalRepository>();

        public IDoctorRepository DoctorRepository =>
            _doctorRepository ??= _serviceProvider.GetService<IDoctorRepository>();

        public IReviewRepository ReviewRepository =>
            _reviewRepository ??= _serviceProvider.GetService<IReviewRepository>();

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}