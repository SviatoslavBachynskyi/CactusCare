using System;

namespace CactusCare.Abstractions.DTOs
{
    public class ReviewDTO
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public DateTime Time { get; set; }

        public int DoctorId { get; set; }

        public DoctorDTO Doctor { get; set; }
    }
}