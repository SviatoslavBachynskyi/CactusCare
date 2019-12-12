using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CactusCare.Abstractions.DTOs;

namespace CactusCare.Abstractions.Services
{
    public interface ISpecialityService
    {
        Task<List<SpecialityDTO>> GetAllAsync();
        
        Task<SpecialityDTO> GetAsync(int id);

        Task InsertAsync(SpecialityDTO specialityDto);

        Task UpdateAsync(SpecialityDTO specialityDto);

        Task DeleteAsync(int id);
    }
}