using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CactusCare.Abstractions.DTOs;
using CactusCare.Abstractions.Services;
using Microsoft.AspNetCore.Mvc;

namespace CactusCareApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpGet]
        public async Task<ActionResult<List<DoctorDTO>>> GetAll()
        {
            return await _doctorService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DoctorDTO>> Get(int id)
        {
            return await _doctorService.GetAsync(id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] DoctorUpdateDTO doctorDto)
        {
            try
            {
                await _doctorService.UpdateAsync(id, doctorDto);
                return StatusCode(200, "OK");
            }
            catch (KeyNotFoundException)
            {
                return StatusCode(404, $"Doctor with id {id} not found");
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}