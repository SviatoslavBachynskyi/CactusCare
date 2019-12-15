using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CactusCare.Abstractions.DTOs;
using CactusCare.Abstractions.Services;
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

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Insert(HospitalDto hospitalDto)
        {
            try
            {
                await this._hospitalService.InsertAsync(hospitalDto);
                return StatusCode(200, "OK");
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] HospitalDto hospitalDto)
        {
            try
            {
                await this._hospitalService.UpdateAsync(hospitalDto);
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

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await this._hospitalService.DeleteAsync(id);
                return StatusCode(200, "OK");
            }
            catch (KeyNotFoundException)
            {
                return StatusCode(404, $"Hospital with {id} not found");
            }
            catch (Exception e)
            {
                return StatusCode(500, "Internal server error: " + e.InnerException);
            }
        }
    }
}