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
    internal class DoctorService : IDoctorService
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;
        public DoctorService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public DoctorDTO Get(int Id)
        {
            var model = _unitOfWork.DoctorRepository.GetById(Id);
            return _mapper.Map<Doctor, DoctorDTO>(model);
        }

        public List<DoctorDTO> GetAll()
        {
            return _unitOfWork.DoctorRepository.GetAll()
                .Select((d) => _mapper.Map<Doctor, DoctorDTO>(d)).ToList();
        }
    }
}
