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

        public HospitalService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        public async Task<List<HospitalDTO>> GetAllAsync()
        {
            return (await this._unitOfWork.HospitalRepository.GetAllAsync())
                .Select(d => _mapper.Map<Hospital, HospitalDTO>(d))
                .ToList();
        }

        public async Task<HospitalDTO> GetAsync(int id)
        {
            return _mapper.Map<Hospital, HospitalDTO>(await this._unitOfWork.HospitalRepository.GetByIdAsync(id));
        }

        public async Task InsertAsync(HospitalDTO hospitalDto)
        {
            await this._unitOfWork.HospitalRepository.InsertAsync(this._mapper.Map<HospitalDTO, Hospital>(hospitalDto));
            await this._unitOfWork.SaveAsync();
        }

        public async Task UpdateAsync(HospitalDTO hospitalDto)
        {
            await this._unitOfWork.HospitalRepository.UpdateAsync(this._mapper.Map<HospitalDTO, Hospital>(hospitalDto));
            await this._unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await this._unitOfWork.HospitalRepository.DeleteAsync(id);
            await this._unitOfWork.SaveAsync();
        }
    }
}