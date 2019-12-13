using System.Collections.Generic;
using System.Threading.Tasks;
using CactusCare.Abstractions.DTOs;

namespace CactusCare.Abstractions.Services
{
    public interface IDoctorService
    {
        Task<List<DoctorDto>> GetAllAsync();

        Task<DoctorDto> GetAsync(int id);

        Task InsertAsync(DoctorDto doctorDto);

        Task UpdateAsync(DoctorDto doctorDto);

        Task DeleteAsync(int id);
    }
}