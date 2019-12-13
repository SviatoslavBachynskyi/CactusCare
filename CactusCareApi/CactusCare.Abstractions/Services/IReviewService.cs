using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CactusCare.Abstractions.DTOs;

namespace CactusCare.Abstractions.Services
{
    public interface IReviewService
    {
        Task<List<ReviewDto>> GetAllAsync();
        
        Task<ReviewDto> GetAsync(int id);

        Task InsertAsync(ReviewDto reviewDto);

        Task UpdateAsync(ReviewDto reviewDto);

        Task DeleteAsync(int id);
    }
}