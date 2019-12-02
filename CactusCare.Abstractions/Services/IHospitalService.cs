using CactusCare.Abstractions.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace CactusCare.Abstractions.Services
{
    public interface IHospitalService
    {
        List<HospitalDTO> GetAll();

        HospitalDTO Get(int id);
    }
}