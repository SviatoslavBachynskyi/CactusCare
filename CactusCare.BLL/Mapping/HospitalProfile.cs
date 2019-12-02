using AutoMapper;
using CactusCare.Abstractions.DTOs;
using CactusCare.Abstractions.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CactusCare.BLL.Mapping
{
    class HospitalProfile : Profile
    {
        public HospitalProfile()
        {
            CreateMap<Hospital, HospitalDTO>();

            CreateMap<HospitalDTO, Hospital>();
        }
    }
}
