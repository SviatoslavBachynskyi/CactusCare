using AutoMapper;
using CactusCare.Abstractions.DTOs;
using CactusCare.Abstractions.Entities;

namespace CactusCare.BLL.Mapping
{
    internal class DoctorProfile : Profile
    {
        public DoctorProfile()
        {
            CreateMap<Doctor, DoctorDTO>();

            CreateMap<DoctorDTO, Doctor>()
                .ForMember(d => d.Speciality, opt => opt.Ignore())
                .ForMember(d => d.Hospital, opt => opt.Ignore())
                .ForMember(d => d.Rating, opt => opt.Ignore());
        }
    }
}