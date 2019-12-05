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
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<SpecialityDTO>> GetAllAsync()
        {
            return (await _unitOfWork.SpecialityRepository.GetAllAsync())
                .Select(d => _mapper.Map<Speciality, SpecialityDTO>(d))
                .ToList();
        }

        public async Task<SpecialityDTO> GetAsync(int id)
        {
            return _mapper.Map<Speciality, SpecialityDTO>(await _unitOfWork.SpecialityRepository.GetByIdAsync(id));
        }

        public async Task InsertAsync(SpecialityDTO specialityDto)
        {
            await _unitOfWork.SpecialityRepository.InsertAsync(_mapper.Map<SpecialityDTO, Speciality>(specialityDto));
        }

        public async Task UpdateAsync(SpecialityDTO specialityDto)
        {
            await _unitOfWork.SpecialityRepository.UpdateAsync(_mapper.Map<SpecialityDTO, Speciality>(specialityDto));
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.SpecialityRepository.DeleteAsync(id);
        }
    }
}