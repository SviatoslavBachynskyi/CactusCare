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
    internal class SpecialityService : ISpecialityService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public SpecialityService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        public async Task<List<SpecialityDTO>> GetAllAsync()
        {
            return (await _unitOfWork.SpecialityRepository.GetAllAsync())
                .Select(d => _mapper.Map<Speciality, SpecialityDTO>(d))
                .ToList();
        }

        public async Task<SpecialityDTO> GetAsync(int id)
        {
            return this._mapper.Map<Speciality, SpecialityDTO>(await this._unitOfWork.SpecialityRepository.GetByIdAsync(id));
        }

        public async Task InsertAsync(SpecialityDTO specialityDto)
        {
            await this._unitOfWork.SpecialityRepository.InsertAsync(this._mapper.Map<SpecialityDTO, Speciality>(specialityDto));
            await this._unitOfWork.SaveAsync();
        }

        public async Task UpdateAsync(SpecialityDTO specialityDto)
        {
            await this._unitOfWork.SpecialityRepository.UpdateAsync(this._mapper.Map<SpecialityDTO, Speciality>(specialityDto));
            await this._unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await this._unitOfWork.SpecialityRepository.DeleteAsync(id);
            await this._unitOfWork.SaveAsync();
        }
    }
}