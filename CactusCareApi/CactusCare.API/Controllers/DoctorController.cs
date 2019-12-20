using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CactusCare.Abstractions.DTOs;
using CactusCare.Abstractions.Services;
using Microsoft.AspNetCore.Authorization;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CactusCare.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService)
        {
            this._doctorService = doctorService;
        }

        [HttpGet]
        public async Task<ActionResult<List<DoctorDto>>> GetAll()
        {
            return await this._doctorService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DoctorDto>> Get(int id)
        {
            return await this._doctorService.GetAsync(id);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Insert(DoctorDto doctorDto)
        {
            await this._doctorService.InsertAsync(doctorDto);
            return Ok();
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] DoctorDto doctorDto)
        {
            try
            {
                await this._doctorService.UpdateAsync(doctorDto);
                return Ok();
            }
            catch (DbUpdateConcurrencyException)
            {
                return StatusCode(404, $"Doctor with id {doctorDto.Id} not found");
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await this._doctorService.DeleteAsync(id);
                return Ok();
            }
            catch (KeyNotFoundException)
            {
                return StatusCode(404, $"Doctor with id {id} not found");
            }
        }
    }
}