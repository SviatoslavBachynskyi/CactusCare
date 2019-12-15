using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CactusCare.Abstractions.DTOs;
using CactusCare.Abstractions.Services;
using Microsoft.AspNetCore.Http;
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
        public async Task<IActionResult> Register(RegisterDto registerDTO)
        {
            await this._authenticationService.RegisterAsync(registerDTO);
            return Ok();
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDto loginDTO)
        {
            try
            {
                return Ok(await this._authenticationService.LoginAsync(loginDTO));
            }
            catch (ApplicationException)
            {
                //TODO check if this is the right result
                return Unauthorized();
            }
        }
    }
}