using AutoMapper;
using CactusCare.Abstractions.DTOs;
using CactusCare.Abstractions.Entities;

namespace CactusCare.BLL.Mapping
{
    internal class DoctorProfile : Profile
    {
        public DoctorProfile()
        {
            CreateMap<Doctor, DoctorDto>();

            CreateMap<DoctorDto, Doctor>()
                .ForMember(d => d.Specialty, opt => opt.Ignore())
                .ForMember(d => d.Hospital, opt => opt.Ignore())
                .ForMember(d => d.Rating, opt => opt.Ignore());
        }
    }
}