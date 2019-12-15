using CactusCare.Abstractions.DTOs;
using FluentValidation;

namespace CactusCare.BLL.Validators
{
    public class SpecialtyDtoValidator : AbstractValidator<SpecialtyDto>
    {
        public SpecialtyDtoValidator()
        {
            RuleFor(s => s.Id).GreaterThanOrEqualTo(0);
            RuleFor(s => s.Name).NotEmpty().Length(5, 50).Matches(@"^([a-zA-Z]+\s)*[a-zA-Z]+$");
        }
    }
}