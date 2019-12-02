using CactusCare.Abstractions.Entities;
using CactusCare.Abstractions.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CactusCare.DAL.Repositories
{
    internal class DoctorRepository : BaseRepository<Doctor,int>,IDoctorRepository
    {
        public DoctorRepository(CactusCareContext context)
            :base(context)
        {

        }

        protected override IQueryable<Doctor> ComplexEntities => _context.Set<Doctor>().Include( d=> d.Speciality);
    }
}
