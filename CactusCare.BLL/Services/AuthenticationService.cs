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

namespace CactusCare.BLL.Services
{
    internal class AuthenticationService : IAuthenticationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        public AuthenticationService(IUnitOfWork unitOfWork, IMapper mapper, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<string> LoginAsync(LoginDTO loginDTO)
        {
            var siginResult = await _unitOfWork.SignInManager.PasswordSignInAsync(loginDTO.UserName, loginDTO.Password, false, false);

            if (siginResult.Succeeded)
            {
                var user = _unitOfWork.UserManager.Users.Single((u) => u.UserName == loginDTO.UserName);
                return GenerateJWTToken(user);
            }

            //TODO Create Custom Exception
            throw new ApplicationException("Login failed");
        }

        public async Task RegisterAsync(RegisterDTO registerDTO)
        {
            var user = _mapper.Map<RegisterDTO, User>(registerDTO);
            var createResult = await _unitOfWork.UserManager.CreateAsync(user, registerDTO.Password);

            if (!createResult.Succeeded)
            {
                throw new ApplicationException("RegisterFailed");
            }

            await _unitOfWork.SaveAsync();
        }

        private string GenerateJWTToken(User user)
        {
            var jwt = _configuration.GetSection("Jwt");

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub,user.Email),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier,user.Id)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt["Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(Convert.ToDouble(jwt["ExpireDays"]));

            var token = new JwtSecurityToken(
                jwt["Issuer"],
                jwt["Issuer"],
                claims,
                expires: expires,
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
