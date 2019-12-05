using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CactusCare.Abstractions.DTOs;
using CactusCare.Abstractions.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CactusCareApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalController : ControllerBase
    {
        private readonly IHospitalService _hospitalService;

        public HospitalController(IHospitalService hospitalService)
        {
            _hospitalService = hospitalService;
        }

        [HttpGet]
        public async Task<ActionResult<List<HospitalDTO>>> GetAll()
        {
            return await _hospitalService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HospitalDTO>> Get(int id)
        {
            return await _hospitalService.GetAsync(id);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] HospitalDTO hospitalDto)
        {
            try
            {
                await _hospitalService.UpdateAsync(hospitalDto);
                return StatusCode(200, "OK");
            }
            catch (DbUpdateConcurrencyException)
            {
                return StatusCode(404, $"Hospital with id {hospitalDto.Id} not found");
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}