using AutoMapper;
using CactusCare.Abstractions.DTOs;
using CactusCare.Abstractions.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CactusCare.BLL.Mapping
{
    class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<RegisterDTO, User>();
        }
    }
}
