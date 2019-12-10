using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CactusCare.Abstractions.DTOs;

namespace CactusCare.Abstractions.Services
{
    public interface IReviewService
    {
        Task<List<ReviewDTO>> GetAllAsync();
        
        Task<ReviewDTO> GetAsync(int id);

        Task InsertAsync(ReviewDTO reviewDto);

        Task UpdateAsync(ReviewDTO reviewDto);

        Task DeleteAsync(int id);
    }
}