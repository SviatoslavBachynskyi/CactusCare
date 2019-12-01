using CactusCare.Abstractions.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace CactusCare.Abstractions.Services
{
    public interface IDoctorService
    {
        List<DoctorDTO> GetAll();

        DoctorDTO Get(int Id);
    }
}
