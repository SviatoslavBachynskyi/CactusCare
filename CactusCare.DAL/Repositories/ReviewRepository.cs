using System.Linq;
using CactusCare.Abstractions.Entities;
using CactusCare.Abstractions.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CactusCare.DAL.Repositories
{
    internal class ReviewRepository : BaseRepository<Review, int>, IReviewRepository
    {
        public ReviewRepository(CactusCareContext context) : base(context)
        {
        }

        protected override IQueryable<Review> ComplexEntities => _context.Set<Review>()
            .Include(d => d.Doctor)
            .Include(s => s.Doctor.Speciality)
            .Include(h => h.Doctor.Hospital);
    }
}