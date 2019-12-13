using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CactusCare.Abstractions.DTOs;

namespace CactusCare.Abstractions.Services
{
    public interface IHospitalService
    {
        Task<List<HospitalDto>> GetAllAsync();
        
        Task<HospitalDto> GetAsync(int id);

        Task InsertAsync(HospitalDto hospitalDto);

        Task UpdateAsync(HospitalDto hospitalDto);

        Task DeleteAsync(int id);
    }
}