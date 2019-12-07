using AutoMapper;
using CactusCare.Abstractions.DTOs;
using CactusCare.Abstractions.Entities;

namespace CactusCare.BLL.Mapping
{
    internal class HospitalProfile : Profile
    {
        public HospitalProfile()
        {
            CreateMap<Hospital, HospitalDTO>();

            CreateMap<HospitalDTO, Hospital>()
                .ForMember(i => i.Id, opt => opt.Ignore());
        }
    }
}