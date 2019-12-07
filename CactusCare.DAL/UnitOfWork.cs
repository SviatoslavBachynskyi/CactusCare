using CactusCare.Abstractions;
using CactusCare.Abstractions.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using CactusCare.Abstractions.Entities;
using Microsoft.AspNetCore.Identity;
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

        private UserManager<User> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        private SignInManager<User> _signInManager;

        public UnitOfWork(CactusCareContext context, IServiceProvider serviceProvider)
        {
            _context = context;
            _serviceProvider = serviceProvider;
        }

        public ISpecialityRepository SpecialityRepository => _specialityRepository ??= _serviceProvider.GetService<ISpecialityRepository>();

        public IHospitalRepository HospitalRepository => _hospitalRepository ??= _serviceProvider.GetService<IHospitalRepository>();

        public IDoctorRepository DoctorRepository => _doctorRepository ??= _serviceProvider.GetService<IDoctorRepository>();

        public UserManager<User> UserManager => _userManager ??= _serviceProvider.GetService<UserManager<User>>();

        public RoleManager<IdentityRole> RoleManager => _roleManager ??= _serviceProvider.GetService<RoleManager<IdentityRole>>();

        public SignInManager<User> SignInManager => _signInManager ??= _serviceProvider.GetService<SignInManager<User>>();

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
