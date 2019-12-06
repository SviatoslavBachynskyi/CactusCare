using System.Collections.Generic;
using System.Data;
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
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<DoctorDTO>> GetAllAsync()
        {
            return (await _unitOfWork.DoctorRepository.GetAllAsync())
                .Select(d => _mapper.Map<Doctor, DoctorDTO>(d))
                .ToList();
        }

        public async Task<DoctorDTO> GetAsync(int id)
        {
            return _mapper.Map<Doctor, DoctorDTO>(await _unitOfWork.DoctorRepository.GetByIdAsync(id));
        }

        public async Task InsertAsync(DoctorDTO doctorDto)
        {
            await _unitOfWork.DoctorRepository.InsertAsync(_mapper.Map<DoctorDTO, Doctor>(doctorDto));
        }

        public async Task UpdateAsync(DoctorDTO doctorDto)
        {
            await _unitOfWork.DoctorRepository.UpdateAsync(_mapper.Map<DoctorDTO, Doctor>(doctorDto));
        }

        public async Task DeleteAsync(int id)
        {
            if ((await _unitOfWork.ReviewRepository.GetAllAsync()).Any(d => d.DoctorId.Equals(id)))
                throw new ConstraintException();

            await _unitOfWork.DoctorRepository.DeleteAsync(id);
        }
    }
}