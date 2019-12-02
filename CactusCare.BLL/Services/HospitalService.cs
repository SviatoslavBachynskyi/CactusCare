using AutoMapper;
using CactusCare.Abstractions;
using CactusCare.Abstractions.DTOs;
using CactusCare.Abstractions.Entities;
using CactusCare.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CactusCare.BLL.Services
{
    internal class HospitalService : IHospitalService
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;
        
        public HospitalService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public HospitalDTO Get(int id)
        {
            var model = _unitOfWork.HospitalRepository.GetById(id);
            return _mapper.Map<Hospital, HospitalDTO>(model);
        }
        
        public List<HospitalDTO> GetAll()
        {
            return _unitOfWork.HospitalRepository.GetAll()
                .Select((s) => _mapper.Map<Hospital, HospitalDTO>(s)).ToList();
        }
    }
}
