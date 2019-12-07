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

        protected override IQueryable<Review> ComplexEntities =>
            Context.Set<Review>().Include(d => d.Doctor);
    }
}