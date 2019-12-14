using CactusCare.Abstractions.DTOs;
using FluentValidation;

namespace CactusCare.BLL.Validators
{
    public class DoctorDtoValidator : AbstractValidator<DoctorDto>
    {
        public DoctorDtoValidator()
        {
            RuleFor(d => d.Id).GreaterThanOrEqualTo(0);
            RuleFor(d => d.FirstName).NotEmpty().Length(5, 50);
            RuleFor(d => d.Patronymic).NotEmpty().Length(5, 50);
            RuleFor(d => d.LastName).NotEmpty().Length(5, 50);
            RuleFor(d => d.Rating).GreaterThanOrEqualTo(0).LessThanOrEqualTo(5);
            RuleFor(d => d.SpecialtyId).GreaterThanOrEqualTo(0);
            RuleFor(d => d.HospitalId).GreaterThanOrEqualTo(0);
        }
    }
}