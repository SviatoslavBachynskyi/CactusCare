using CactusCare.Abstractions.DTOs;
using FluentValidation;

namespace CactusCare.BLL.Validators
{
    public class RegisterDtoValidator : AbstractValidator<RegisterDto>
    {
        public RegisterDtoValidator()
        {
            RuleFor(r => r.UserName).NotEmpty().Length(5, 50);
            RuleFor(r => r.Password).NotEmpty().Length(5, 50);
            RuleFor(r => r.FirstName).NotEmpty().Length(5, 50);
            RuleFor(r => r.LastName).NotEmpty().Length(5, 50);
        }
    }
}