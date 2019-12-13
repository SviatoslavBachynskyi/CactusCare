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
    internal class SpecialtyService : ISpecialtyService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public SpecialtyService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        public async Task<List<SpecialtyDto>> GetAllAsync()
        {
            return (await _unitOfWork.SpecialtyRepository.GetAllAsync())
                .Select(d => _mapper.Map<Specialty, SpecialtyDto>(d))
                .ToList();
        }

        public async Task<SpecialtyDto> GetAsync(int id)
        {
            return this._mapper.Map<Specialty, SpecialtyDto>(await this._unitOfWork.SpecialtyRepository.GetByIdAsync(id));
        }

        public async Task InsertAsync(SpecialtyDto specialityDto)
        {
            await this._unitOfWork.SpecialtyRepository.InsertAsync(this._mapper.Map<SpecialtyDto, Specialty>(specialityDto));
            await this._unitOfWork.SaveAsync();
        }

        public async Task UpdateAsync(SpecialtyDto specialityDto)
        {
            await this._unitOfWork.SpecialtyRepository.UpdateAsync(this._mapper.Map<SpecialtyDto, Specialty>(specialityDto));
            await this._unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await this._unitOfWork.SpecialtyRepository.DeleteAsync(id);
            await this._unitOfWork.SaveAsync();
        }
    }
}