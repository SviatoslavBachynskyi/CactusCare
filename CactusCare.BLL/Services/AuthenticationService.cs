using AutoMapper;
using CactusCare.Abstractions;
using CactusCare.Abstractions.DTOs;
using CactusCare.Abstractions.Entities;
using CactusCare.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CactusCare.BLL.Services
{
    internal class AuthenticationService : IAuthenticationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public AuthenticationService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task RegisterAsync(RegisterDTO registerDTO)
        {
            var user = _mapper.Map<RegisterDTO, User>(registerDTO);
            await _unitOfWork.UserManager.CreateAsync(user, registerDTO.Password);

            await _unitOfWork.SaveAsync();
        }
    }
}
