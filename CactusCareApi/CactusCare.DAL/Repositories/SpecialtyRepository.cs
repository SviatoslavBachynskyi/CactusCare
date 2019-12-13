using CactusCare.Abstractions.Entities;
using CactusCare.Abstractions.Repositories;

namespace CactusCare.DAL.Repositories
{
    internal class SpecialtyRepository : BaseRepository<Specialty, int>, ISpecialtyRepository
    {
        public SpecialtyRepository(CactusCareContext context) : base(context)
        {
        }
    }
}