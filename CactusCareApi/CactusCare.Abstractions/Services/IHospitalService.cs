using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CactusCare.Abstractions.DTOs;

namespace CactusCare.Abstractions.Services
{
    public interface IHospitalService
    {
        Task<List<HospitalDTO>> GetAllAsync();
        
        Task<HospitalDTO> GetAsync(int id);

        Task InsertAsync(HospitalDTO hospitalDto);

        Task UpdateAsync(HospitalDTO hospitalDto);

        Task DeleteAsync(int id);
    }
}