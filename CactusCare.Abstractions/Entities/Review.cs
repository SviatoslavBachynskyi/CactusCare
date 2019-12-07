using System;

namespace CactusCare.Abstractions.Entities
{
    public class Review : IEntity<int>
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public DateTime Time { get; set; }

        public int DoctorId { get; set; }

        public Doctor Doctor { get; set; }

        public int Rating { get; set; }
    }
}