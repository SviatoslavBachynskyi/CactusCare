using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CactusCare.Abstractions;
using CactusCare.Abstractions.DTOs;
using CactusCare.Abstractions.Entities;
using CactusCare.Abstractions.Services;

namespace CactusCare.BLL.Services
{
    internal class DoctorService : IDoctorService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public DoctorService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        public async Task<List<DoctorDTO>> GetAllAsync()
        {
            return (await this._unitOfWork.DoctorRepository.GetAllAsync())
                .Select(d => _mapper.Map<Doctor, DoctorDTO>(d))
                .ToList();
        }

        public async Task<DoctorDTO> GetAsync(int id)
        {
            return this._mapper.Map<Doctor, DoctorDTO>(await this._unitOfWork.DoctorRepository.GetByIdAsync(id));
        }

        public async Task InsertAsync(DoctorDTO doctorDto)
        {
            await this._unitOfWork.DoctorRepository.InsertAsync(this._mapper.Map<DoctorDTO, Doctor>(doctorDto));
            await this._unitOfWork.SaveAsync();
        }

        public async Task UpdateAsync(DoctorDTO doctorDto)
        {
            await this._unitOfWork.DoctorRepository.UpdateAsync(this._mapper.Map<DoctorDTO, Doctor>(doctorDto));
            await this._unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await this._unitOfWork.DoctorRepository.DeleteAsync(id);
            await this._unitOfWork.SaveAsync();
        }
    }
}