using CactusCare.Abstractions.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using CactusCare.Abstractions.Entities;
using Microsoft.AspNetCore.Identity;

namespace CactusCare.Abstractions
{
    public interface IUnitOfWork
    {
        ISpecialityRepository SpecialityRepository { get; }
        
        IHospitalRepository HospitalRepository { get; }

        IDoctorRepository DoctorRepository { get; }

        UserManager<User> UserManager { get; }

        RoleManager<IdentityRole> RoleManager { get; }

        void Save();
    }
}
