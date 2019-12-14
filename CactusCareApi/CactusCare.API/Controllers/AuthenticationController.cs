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
            try
            {
                await this._authenticationService.RegisterAsync(registerDto);
                return Ok();
            }
            catch (ValidationException exception)
            {
                return StatusCode(400, exception.Errors.Select(x => x.ErrorMessage));
            }
        }

        [HttpPost("Login")]
        public async Task<ActionResult> Login(LoginDto loginDto)
        {
            try
            {
                await this._authenticationService.LoginAsync(loginDto);
                return Ok();
            }
            catch (ValidationException exception)
            {
                return StatusCode(400, exception.Errors.Select(x => x.ErrorMessage));
            }
            catch (ApplicationException)
            {
                //TODO check if this is the right result
                return Unauthorized();
            }
        }
    }
}