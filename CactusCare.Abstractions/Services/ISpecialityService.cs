using CactusCare.Abstractions.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace CactusCare.Abstractions.Services
{
    public interface ISpecialityService
    {
        public List<SpecialityDTO> GetAll();

        public SpecialityDTO Get(int Id);
    }
}
