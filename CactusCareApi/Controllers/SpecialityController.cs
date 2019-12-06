using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using CactusCare.Abstractions.DTOs;
using CactusCare.Abstractions.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CactusCareApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialityController : ControllerBase
    {
        private readonly ISpecialityService _specialityService;

        public SpecialityController(ISpecialityService specialityService)
        {
            _specialityService = specialityService;
        }

        [HttpGet]
        public async Task<ActionResult<List<SpecialityDTO>>> GetAll()
        {
            return await _specialityService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SpecialityDTO>> Get(int id)
        {
            return await _specialityService.GetAsync(id);
        }

        [HttpPost]
        public async Task<IActionResult> Insert(SpecialityDTO specialityDto)
        {
            try
            {
                await _specialityService.InsertAsync(specialityDto);
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
                await _specialityService.UpdateAsync(specialityDto);
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
            catch (ConstraintException)
            {
                return StatusCode(400,
                    $"Speciality with id {id} has relationship with Doctor. Remove all doctors associated with it first");
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}