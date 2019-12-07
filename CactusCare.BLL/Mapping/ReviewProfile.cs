using AutoMapper;
using CactusCare.Abstractions.DTOs;
using CactusCare.Abstractions.Entities;

namespace CactusCare.BLL.Mapping
{
    public class ReviewProfile : Profile
    {
        public ReviewProfile()
        {
            CreateMap<Review, ReviewDTO>();

            CreateMap<ReviewDTO, Review>()
                .ForMember(d => d.Doctor, opt => opt.Ignore());
        }
    }
}