using System;
using System.Threading.Tasks;
using CactusCare.Abstractions;
using CactusCare.Abstractions.Entities;
using CactusCare.Abstractions.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace CactusCare.DAL
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly CactusCareContext _context;
        private readonly IServiceProvider _serviceProvider;
        private IDoctorRepository _doctorRepository;
        private IHospitalRepository _hospitalRepository;
        private IReviewRepository _reviewRepository;
        private ISpecialtyRepository _specialtyRepository;

        private UserManager<User> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        private SignInManager<User> _signInManager;

        public UnitOfWork(CactusCareContext context, IServiceProvider serviceProvider)
        {
            this._context = context;
            this._serviceProvider = serviceProvider;
        }

        public ISpecialtyRepository SpecialtyRepository =>
            this._specialtyRepository ??= this._serviceProvider.GetService<ISpecialtyRepository>();

        public IHospitalRepository HospitalRepository =>
            this._hospitalRepository ??= this._serviceProvider.GetService<IHospitalRepository>();

        public IDoctorRepository DoctorRepository =>
            this._doctorRepository ??= this._serviceProvider.GetService<IDoctorRepository>();

        public IReviewRepository ReviewRepository =>
            this._reviewRepository ??= this._serviceProvider.GetService<IReviewRepository>();

        public UserManager<User> UserManager =>
            this._userManager ??= this._serviceProvider.GetService<UserManager<User>>();

        public RoleManager<IdentityRole> RoleManager =>
            this._roleManager ??= this._serviceProvider.GetService<RoleManager<IdentityRole>>();

        public SignInManager<User> SignInManager =>
            this._signInManager ??= this._serviceProvider.GetService<SignInManager<User>>();

        public async Task<int> SaveAsync()
        {
            return await this._context.SaveChangesAsync();
        }
    }
}