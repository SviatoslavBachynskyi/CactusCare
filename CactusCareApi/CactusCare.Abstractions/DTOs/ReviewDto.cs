using System;

namespace CactusCare.Abstractions.DTOs
{
    public class ReviewDto
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public DateTime Time { get; set; }

        public int DoctorId { get; set; }

        public DoctorDto Doctor { get; set; }

        public int Rating { get; set; }
    }
}