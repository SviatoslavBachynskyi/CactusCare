namespace CactusCare.Abstractions.DTOs
{
    public class DoctorUpdateDTO
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int SpecialityId { get; set; }

        public int HospitalId { get; set; }
    }
}