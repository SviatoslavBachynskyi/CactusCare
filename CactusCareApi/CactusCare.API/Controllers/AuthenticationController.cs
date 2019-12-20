using System;
using System.Linq;
using System.Threading.Tasks;
using CactusCare.Abstractions.DTOs;
using CactusCare.Abstractions.Services;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace CactusCare.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            this._authenticationService = authenticationService;
        }

        [HttpPost("Register")]
        public async Task<ActionResult> Register(RegisterDto registerDto)
        {
            await this._authenticationService.RegisterAsync(registerDto);
            return Ok();
        }

        [HttpPost("Login")]
        public async Task<ActionResult> Login(LoginDto loginDto)
        {
            try
            {
                return Ok(await this._authenticationService.LoginAsync(loginDto));
            }
            catch (ApplicationException)
            {
                return Unauthorized();
            }
        }
    }
}