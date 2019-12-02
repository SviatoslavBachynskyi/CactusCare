using CactusCare.Abstractions.Entities;
using CactusCare.Abstractions.Repositories;

namespace CactusCare.DAL.Repositories
{
    internal class ReviewRepository : BaseRepository<Review, int>, IReviewRepository
    {
        public ReviewRepository(CactusCareContext context) : base(context)
        {
        }
    }
}