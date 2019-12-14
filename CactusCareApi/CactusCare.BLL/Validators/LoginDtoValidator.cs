using CactusCare.Abstractions.DTOs;
using FluentValidation;

namespace CactusCare.BLL.Validators
{
    public class LoginDtoValidator : AbstractValidator<LoginDto>
    {
        public LoginDtoValidator()
        {
            
        }
    }
}