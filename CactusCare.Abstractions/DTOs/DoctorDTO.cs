using System;
using System.Collections.Generic;
using System.Text;

namespace CactusCare.Abstractions.DTOs
{
    public class DoctorDTO
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int SpecialityId { get; set; }

        public SpecialityDTO Speciality { get; set; }
    }
}
