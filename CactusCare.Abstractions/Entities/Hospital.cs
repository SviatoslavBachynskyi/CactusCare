﻿using System.Collections.Generic;

namespace CactusCare.Abstractions.Entities
{
    public class Hospital : IEntity<int>
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public string Address { get; set; }
        
        public string Email { get; set; }
        
        public string PhoneNumber { get; set; }
        
        public string Website { get; set; }
        
        public List<Doctor> Doctors { get; set; }
    }
}