﻿using CactusCare.Abstractions.DTOs;
using FluentValidation;

namespace CactusCare.BLL.Validators
{
    public class LoginDtoValidator : AbstractValidator<LoginDto>
    {
        public LoginDtoValidator()
        {
            RuleFor(l => l.UserName).NotEmpty().Length(4, 20).Matches(@"^[a-zA-Z0-9]+([_ -]?[a-zA-Z0-9])*$");
            RuleFor(l => l.Password).NotEmpty().Length(6, 20);
        }
    }
}