using System.Collections.Generic;
using System.Threading.Tasks;
using CactusCare.Abstractions.DTOs;

namespace CactusCare.Abstractions.Services
{
    public interface IDoctorService
    {
        Task<List<DoctorDTO>> GetAllAsync();

        Task<DoctorDTO> GetAsync(int id);

        Task InsertAsync(DoctorDTO doctorDto);

        Task UpdateAsync(int id, DoctorUpdateDTO doctorDto);

        Task DeleteAsync(int id);
    }
}