using System.Linq;
using CactusCare.Abstractions.Entities;
using CactusCare.Abstractions.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CactusCare.DAL.Repositories
{
    internal class DoctorRepository : BaseRepository<Doctor, int>, IDoctorRepository
    {
        public DoctorRepository(CactusCareContext context) : base(context)
        {
        }

        protected override IQueryable<Doctor> ComplexEntities =>
            Context.Set<Doctor>().Include(d => d.Speciality).Include(d => d.Hospital);
    }
}    