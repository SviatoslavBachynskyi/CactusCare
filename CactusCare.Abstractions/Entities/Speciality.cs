using System;
using System.Collections.Generic;
using System.Text;

namespace CactusCare.Abstractions.Entities
{
    public class Speciality : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Doctor> Doctors { get; set; }
    }
}
