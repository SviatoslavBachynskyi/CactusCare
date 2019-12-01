using AutoMapper;
using CactusCare.Abstractions.DTOs;
using CactusCare.Abstractions.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CactusCare.BLL.Mapping
{
    class DoctorProfile : Profile
    {
        public DoctorProfile()
        {
            CreateMap<Doctor, DoctorDTO>();
            CreateMap<DoctorDTO, Doctor>()
                .ForMember(d => d.Speciality, opt => opt.Ignore());
        }
    }
}
