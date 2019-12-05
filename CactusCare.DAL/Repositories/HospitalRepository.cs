using CactusCare.Abstractions.Entities;
using CactusCare.Abstractions.Repositories;

namespace CactusCare.DAL.Repositories
{
    internal class HospitalRepository : BaseRepository<Hospital, int>, IHospitalRepository
    {
        public HospitalRepository(CactusCareContext context) : base(context)
        {
        }
    }
}