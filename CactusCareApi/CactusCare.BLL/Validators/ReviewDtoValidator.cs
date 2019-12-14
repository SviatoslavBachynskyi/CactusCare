using CactusCare.Abstractions.DTOs;
using FluentValidation;

namespace CactusCare.BLL.Validators
{
    public class ReviewDtoValidator : AbstractValidator<ReviewDto>
    {
        public ReviewDtoValidator()
        {
            RuleFor(r => r.Id).GreaterThanOrEqualTo(0);
            RuleFor(r => r.Content).NotEmpty().Length(30, 500);
            RuleFor(r => r.Time);
            RuleFor(r => r.DoctorId).GreaterThanOrEqualTo(0);
            RuleFor(r => r.Rating).GreaterThanOrEqualTo(1).LessThanOrEqualTo(10);
        }
    }
}