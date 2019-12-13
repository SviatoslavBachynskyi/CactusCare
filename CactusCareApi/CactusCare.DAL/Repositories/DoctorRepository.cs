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
            this.Context.Set<Doctor>().Include(d => d.Specialty).Include(d => d.Hospital).AsTracking();
    }
}