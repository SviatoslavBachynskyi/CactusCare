using AutoMapper;
using CactusCare.Abstractions.DTOs;
using CactusCare.Abstractions.Entities;

namespace CactusCare.BLL.Mapping
{
    internal class SpecialityProfile : Profile
    {
        public SpecialityProfile()
        {
            CreateMap<Specialty, SpecialtyDto>();

            CreateMap<SpecialtyDto, Specialty>();
        }
    }
}