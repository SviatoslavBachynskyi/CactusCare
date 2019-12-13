using System;
using System.Collections.Generic;
using System.Text;

namespace CactusCare.Abstractions.DTOs
{
    public class DoctorDto
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string Patronymic { get; set; }

        public string LastName { get; set; }
        
        public float Rating { get; set; }

        public int SpecialtyId { get; set; }

        public SpecialtyDto Specialty { get; set; }
        
        public int HospitalId { get; set; }
        
        public HospitalDto Hospital { get; set; }
    }
}