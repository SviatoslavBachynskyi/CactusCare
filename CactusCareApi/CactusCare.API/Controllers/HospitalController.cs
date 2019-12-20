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
    public class HospitalController : ControllerBase
    {
        private readonly IHospitalService _hospitalService;

        public HospitalController(IHospitalService hospitalService)
        {
            this._hospitalService = hospitalService;
        }

        [HttpGet]
        public async Task<ActionResult<List<HospitalDto>>> GetAll()
        {
            return await this._hospitalService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HospitalDto>> Get(int id)
        {
            return await this._hospitalService.GetAsync(id);
        }

        [Authorize(Roles = Role.Admin)]
        [HttpPost]
        public async Task<IActionResult> Insert(HospitalDto hospitalDto)
        {
            await this._hospitalService.InsertAsync(hospitalDto);
            return Ok();
        }

        [Authorize(Roles = Role.Admin)]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] HospitalDto hospitalDto)
        {
            try
            {
                await this._hospitalService.UpdateAsync(hospitalDto);
                return Ok();
            }
            catch (DbUpdateConcurrencyException)
            {
                return StatusCode(404, $"Hospital with id {hospitalDto.Id} not found");
            }
        }

        [Authorize(Roles = Role.Admin)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await this._hospitalService.DeleteAsync(id);
                return Ok();
            }
            catch (KeyNotFoundException)
            {
                return StatusCode(404, $"Hospital with {id} not found");
            }
        }
    }
}