﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CactusCare.Abstractions.DTOs
{
    public class HospitalDTO
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public string Address { get; set; }
        
        public string Email { get; set; }
        
        public string PhoneNumber { get; set; }
        
        public string Website { get; set; }
    }
}