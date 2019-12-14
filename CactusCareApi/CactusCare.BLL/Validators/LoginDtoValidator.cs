using CactusCare.Abstractions.DTOs;
using FluentValidation;

namespace CactusCare.BLL.Validators
{
    public class LoginDtoValidator : AbstractValidator<LoginDto>
    {
        public LoginDtoValidator()
        {
            RuleFor(l => l.UserName).NotEmpty().Length(5, 50);
            RuleFor(l => l.Password).NotEmpty().Length(5, 50);
        }
    }
}