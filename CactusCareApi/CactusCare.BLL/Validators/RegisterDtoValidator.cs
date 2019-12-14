using CactusCare.Abstractions.DTOs;
using FluentValidation;

namespace CactusCare.BLL.Validators
{
    public class RegisterDtoValidator : AbstractValidator<RegisterDto>
    {
        public RegisterDtoValidator()
        {
            RuleFor(r => r.UserName).NotEmpty().Length(4, 20).Matches(@"^[a-zA-Z0-9]+([_ -]?[a-zA-Z0-9])*$");
            RuleFor(r => r.Password).NotEmpty().Length(6, 20);
            RuleFor(r => r.FirstName).NotEmpty().Length(5, 20).Matches(@"^[a-zA-Z]+$");
            RuleFor(r => r.LastName).NotEmpty().Length(5, 20).Matches(@"^[a-zA-Z]+$");
        }
    }
}