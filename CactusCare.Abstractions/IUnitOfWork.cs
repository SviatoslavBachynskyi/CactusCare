using CactusCare.Abstractions.Entities;
using CactusCare.Abstractions.Repositories;
using Microsoft.AspNetCore.Identity;

namespace CactusCare.Abstractions
{
    public interface IUnitOfWork
    {
        ISpecialityRepository SpecialityRepository { get; }

        IHospitalRepository HospitalRepository { get; }

        IDoctorRepository DoctorRepository { get; }

        IReviewRepository ReviewRepository { get; }

        UserManager<User> UserManager { get; }

        RoleManager<IdentityRole> RoleManager { get; }
    }
}