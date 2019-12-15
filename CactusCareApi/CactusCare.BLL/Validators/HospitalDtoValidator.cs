using CactusCare.Abstractions.DTOs;
using FluentValidation;

namespace CactusCare.BLL.Validators
{
    public class HospitalDtoValidator : AbstractValidator<HospitalDto>
    {
        public HospitalDtoValidator()
        {
            RuleFor(h => h.Id).GreaterThanOrEqualTo(0);
            RuleFor(h => h.Name).NotEmpty().Length(5, 50);
            RuleFor(h => h.Address).NotEmpty().Length(5, 50);
            RuleFor(h => h.Email).EmailAddress();
            RuleFor(h => h.PhoneNumber).NotEmpty().Length(10);
            RuleFor(h => h.Website).NotEmpty().Length(5, 30);
        }
    }
}