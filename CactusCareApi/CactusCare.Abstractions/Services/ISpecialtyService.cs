using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CactusCare.Abstractions.DTOs;

namespace CactusCare.Abstractions.Services
{
    public interface ISpecialtyService
    {
        Task<List<SpecialtyDto>> GetAllAsync();
        
        Task<SpecialtyDto> GetAsync(int id);

        Task InsertAsync(SpecialtyDto specialityDto);

        Task UpdateAsync(SpecialtyDto specialityDto);

        Task DeleteAsync(int id);
    }
}