using AutoMapper;
using CactusCare.Abstractions;
using CactusCare.Abstractions.DTOs;
using CactusCare.Abstractions.Entities;
using CactusCare.Abstractions.Services;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using System.Linq;
using CactusCare.BLL.Identity;
using FluentValidation;

namespace CactusCare.BLL.Services
{
    internal class AuthenticationService : IAuthenticationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IValidationService _validationService;

        private readonly JwtTokenGenerator _tokenGenerator;

        public AuthenticationService(IUnitOfWork unitOfWork, IMapper mapper, IConfiguration configuration, JwtTokenGenerator tokenGenerator, IValidationService validationService)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
            this._tokenGenerator = tokenGenerator;
            this._validationService = validationService;
        }

        public async Task<string> LoginAsync(LoginDto loginDto)
        {
            var validationResult = await _validationService.ValidateAsync(loginDto);
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);
            
            var signInResult = await this._unitOfWork.SignInManager.PasswordSignInAsync(loginDto.UserName, loginDto.Password, false, false);

            if (signInResult.Succeeded)
            {
                var user = this._unitOfWork.UserManager.Users.Single((u) => u.UserName == loginDto.UserName);
                return this._tokenGenerator.Generate(user);
            }

            //TODO Create Custom Exception
            throw new ApplicationException("Login failed");
        }

        public async Task RegisterAsync(RegisterDto registerDto)
        {
            var validationResult = await _validationService.ValidateAsync(registerDto);
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);
            
            var user = this._mapper.Map<RegisterDto, User>(registerDto);
            var createResult = await this._unitOfWork.UserManager.CreateAsync(user, registerDto.Password);

            if (!createResult.Succeeded)
            {
                throw new ApplicationException("RegisterFailed");
            }

            await this._unitOfWork.SaveAsync();
        }
    }
}
