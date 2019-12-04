using System;
using System.Collections.Generic;
using System.Text;

namespace CactusCare.Abstractions.Entities
{
    public class Doctor : IEntity<int>
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int SpecialityId { get; set; }

        public Speciality Speciality { get; set; }

        public int HospitalId { get; set; }

        public Hospital Hospital { get; set; }

        public List<Review> Reviews { get; set; }
    }
}