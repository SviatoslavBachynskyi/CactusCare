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
    internal class SpecialityService : ISpecialityService
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;
        public SpecialityService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public SpecialityDTO Get(int Id)
        {
            var model = _unitOfWork.SpecialityRepository.GetById(Id);
            return _mapper.Map<Speciality, SpecialityDTO>(model);
        }

        public List<SpecialityDTO> GetAll()
        {
            return _unitOfWork.SpecialityRepository.GetAll()
                .Select((s) => _mapper.Map<Speciality, SpecialityDTO>(s)).ToList();
        }
    }
}
