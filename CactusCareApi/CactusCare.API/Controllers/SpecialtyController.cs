using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CactusCare.Abstractions;
using CactusCare.Abstractions.DTOs;
using CactusCare.Abstractions.Services;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CactusCare.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialtyController : ControllerBase
    {
        private readonly ISpecialtyService _specialtyService;

        public SpecialtyController(ISpecialtyService specialtyService)
        {
            this._specialtyService = specialtyService;
        }

        [HttpGet]
        public async Task<ActionResult<List<SpecialtyDto>>> GetAll()
        {
            return await this._specialtyService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SpecialtyDto>> Get(int id)
        {
            return await this._specialtyService.GetAsync(id);
        }

        [Authorize(Roles = Role.Admin)]
        [HttpPost]
        public async Task<IActionResult> Insert(SpecialtyDto specialityDto)
        {
                await this._specialtyService.InsertAsync(specialityDto);
                return Ok();
        }

        [Authorize(Roles = Role.Admin)]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] SpecialtyDto specialityDto)
        {
            try
            {
                await this._specialtyService.UpdateAsync(specialityDto);
                return Ok();
            }
            //TODO check this exception
            catch (DbUpdateConcurrencyException)
            {
                return StatusCode(404, $"Specialty with id {specialityDto.Id} not found");
            }
        }

        [Authorize(Roles = Role.Admin)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await this._specialtyService.DeleteAsync(id);
                return Ok();
            }
            catch (KeyNotFoundException)
            {
                return StatusCode(404, $"Specialty with id {id} not found");
            }
        }
    }
}