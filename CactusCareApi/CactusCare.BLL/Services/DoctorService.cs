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
        private readonly IValidationService _validationService;

        public DoctorService(IUnitOfWork unitOfWork, IMapper mapper, IValidationService validationService)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
            this._validationService = validationService;
        }

        public async Task<List<DoctorDto>> GetAllAsync()
        {
            return (await this._unitOfWork.DoctorRepository.GetAllAsync())
                .Select(d => _mapper.Map<Doctor, DoctorDto>(d))
                .ToList();
        }

        public async Task<DoctorDto> GetAsync(int id)
        {
            return this._mapper.Map<Doctor, DoctorDto>(await this._unitOfWork.DoctorRepository.GetByIdAsync(id));
        }

        public async Task InsertAsync(DoctorDto doctorDto)
        {
            await this._unitOfWork.DoctorRepository.InsertAsync(this._mapper.Map<DoctorDto, Doctor>(doctorDto));
            await this._unitOfWork.SaveAsync();
        }

        public async Task UpdateAsync(DoctorDto doctorDto)
        {
            await this._unitOfWork.DoctorRepository.UpdateAsync(this._mapper.Map<DoctorDto, Doctor>(doctorDto));
            await this._unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await this._unitOfWork.DoctorRepository.DeleteAsync(id);
            await this._unitOfWork.SaveAsync();
        }
    }
}