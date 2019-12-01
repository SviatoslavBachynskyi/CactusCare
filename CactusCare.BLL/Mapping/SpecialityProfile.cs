using AutoMapper;
using CactusCare.Abstractions.DTOs;
using CactusCare.Abstractions.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CactusCare.BLL.Mapping
{
    class SpecialityProfile : Profile
    {
        public SpecialityProfile()
        {
            CreateMap<Speciality, SpecialityDTO>();

            CreateMap<SpecialityDTO, Speciality>();
        }
    }
}
