using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CactusCare.Abstractions.DTOs;

namespace CactusCare.Abstractions.Services
{
    public interface IDoctorService
    {
        Task<List<DoctorDTO>> GetAllAsync();
        
        Task<DoctorDTO> GetAsync(int id);

        Task InsertAsync(DoctorDTO doctorDto);

        Task UpdateAsync(DoctorDTO doctorDto);

        Task DeleteAsync(int id);
    }
}