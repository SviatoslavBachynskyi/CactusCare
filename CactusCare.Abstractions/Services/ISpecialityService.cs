using CactusCare.Abstractions.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace CactusCare.Abstractions.Services
{
    public interface ISpecialityService
    {
        List<SpecialityDTO> GetAll();

        SpecialityDTO Get(int Id);
    }
}
