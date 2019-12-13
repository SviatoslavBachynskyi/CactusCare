using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CactusCare.Abstractions.DTOs;
using CactusCare.Abstractions.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CactusCare.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialityController : ControllerBase
    {
        private readonly ISpecialityService _specialityService;

        public SpecialityController(ISpecialityService specialityService)
        {
            this._specialityService = specialityService;
        }

        [HttpGet]
        public async Task<ActionResult<List<SpecialityDTO>>> GetAll()
        {
            return await this._specialityService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SpecialityDTO>> Get(int id)
        {
            return await this._specialityService.GetAsync(id);
        }

        [HttpPost]
        public async Task<IActionResult> Insert(SpecialityDTO specialityDto)
        {
            try
            {
                await this._specialityService.InsertAsync(specialityDto);
                return StatusCode(200, "OK");
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] SpecialityDTO specialityDto)
        {
            try
            {
                await this._specialityService.UpdateAsync(specialityDto);
                return StatusCode(200, "OK");
            }
            catch (DbUpdateConcurrencyException)
            {
                return StatusCode(404, $"Speciality with id {specialityDto.Id} not found");
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _specialityService.DeleteAsync(id);
                return StatusCode(200, "OK");
            }
            catch (KeyNotFoundException)
            {
                return StatusCode(404, $"Speciality with id {id} not found");
            }
            catch (Exception e)
            {
                return StatusCode(500, "Internal server error: " + e.InnerException);
            }
        }
    }
}