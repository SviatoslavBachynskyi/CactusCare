using CactusCare.Abstractions.Entities;
using CactusCare.Abstractions.Repositories;

namespace CactusCare.DAL.Repositories
{
    internal class SpecialityRepository : BaseRepository<Speciality, int>, ISpecialityRepository
    {
        public SpecialityRepository(CactusCareContext context) : base(context)
        {
        }
    }
}