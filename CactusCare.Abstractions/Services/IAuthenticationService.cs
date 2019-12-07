using CactusCare.Abstractions.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CactusCare.Abstractions.Services
{
    public interface IAuthenticationService
    {
        Task RegisterAsync(RegisterDTO registerDTO);
    }
}
