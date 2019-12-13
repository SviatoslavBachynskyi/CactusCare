using System.Collections.Generic;

namespace CactusCare.Abstractions.Entities
{
    public class Doctor : IEntity<int>
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string Patronymic { get; set; }

        public string LastName { get; set; }

        public float Rating { get; set; }

        public int SpecialtyId { get; set; }

        public Specialty Specialty { get; set; }

        public int HospitalId { get; set; }

        public Hospital Hospital { get; set; }

        public List<Review> Reviews { get; set; }
    }
}