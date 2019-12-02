using System.Collections.Generic;
using CactusCare.Abstractions.DTOs;

namespace CactusCare.Abstractions.Services
{
    public interface IReviewService
    {
        List<ReviewDTO> GetAll();

        ReviewDTO Get(int id);
    }
}