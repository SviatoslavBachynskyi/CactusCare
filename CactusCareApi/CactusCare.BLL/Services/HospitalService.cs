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
    internal class HospitalService : IHospitalService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidationService _validationService;

        public HospitalService(IUnitOfWork unitOfWork, IMapper mapper, IValidationService validationService)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
            this._validationService = validationService;
        }

        public async Task<List<HospitalDto>> GetAllAsync()
        {
            return (await this._unitOfWork.HospitalRepository.GetAllAsync())
                .Select(d => _mapper.Map<Hospital, HospitalDto>(d))
                .ToList();
        }

        public async Task<HospitalDto> GetAsync(int id)
        {
            return _mapper.Map<Hospital, HospitalDto>(await this._unitOfWork.HospitalRepository.GetByIdAsync(id));
        }

        public async Task InsertAsync(HospitalDto hospitalDto)
        {
            await this._unitOfWork.HospitalRepository.InsertAsync(this._mapper.Map<HospitalDto, Hospital>(hospitalDto));
            await this._unitOfWork.SaveAsync();
        }

        public async Task UpdateAsync(HospitalDto hospitalDto)
        {
            await this._unitOfWork.HospitalRepository.UpdateAsync(this._mapper.Map<HospitalDto, Hospital>(hospitalDto));
            await this._unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await this._unitOfWork.HospitalRepository.DeleteAsync(id);
            await this._unitOfWork.SaveAsync();
        }
    }
}